using Firebase.Database;
using Firebase.Extensions;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Escenarios : MonoBehaviour   
{

    DatabaseReference reference;

    private int idUser;
    private string nivel;
    private string nameEscenario;


    public GameObject defaultBlock;
    public GameObject bodegaBlock;
    public GameObject playaBlock;
    public GameObject discoBlock;
    public GameObject luchaBlock;
    public List<GameObject> blocks;
    
    public GameObject defaultSelect;
    public GameObject bodegaSelect;
    public GameObject playaSelect;
    public GameObject discoSelect;
    public GameObject luchaSelect;
    public List<GameObject> selects;

    public Text defaultT;
    public Text bodegaT;
    public Text playaT;
    public Text discoT;
    public Text luchaT;
    public List<Text> texts;
    public int escenario;

    public GameObject play;

    // Start is called before the first frame update
    void Start()
    {
        blocks = new List<GameObject>();
        selects = new List<GameObject>();
        texts = new List<Text>();

        addUI();
        LoadData();
        chargeLevels();
        Debug.Log("HOLA" + idUser);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData()
    {
        idUser = DataBetweenScenes.instance.GetUserId();
    }

    public void chargeLevels()
    {
        Debug.Log("HOLA!");
           Debug.Log(idUser.ToString()+" "+idUser);
        FirebaseDatabase.DefaultInstance
       .GetReference("usuarios").Child(idUser.ToString()).Child("nivel")
       .GetValueAsync().ContinueWithOnMainThread(task =>
       {
           if (task.IsFaulted)
           {
               // Handle the error...
               DataSnapshot snapshot = task.Result;
               Debug.Log("Error");
           }
           else if (task.IsCompleted)
           {
               DataSnapshot snapshot = task.Result;
               Debug.Log("Success " + snapshot.GetRawJsonValue());
               // Do something with snapshot...

               nivel = snapshot.GetRawJsonValue();
              
               Nivel level = FactoryNivel.getNivel(nivel);
               enableLevels(level);
           }
       });
     }


    private void enableLevels(Nivel level) {
        Debug.Log(level.escenario().Count+"hola");
        Debug.Log(level.escenario()[0].getNombre());
        disableBlock(level);



    }

    private void disableBlock(Nivel level) {
        int loop = 0;
        Debug.Log("Entre:" + level.escenario());

        foreach (Escenario element in level.escenario())
        {
            Debug.Log("Entre:" + element.getNombre());
            blocks[loop].SetActive(false);
            selects[loop].SetActive(true);
            texts[loop].text = element.getNombre();
            loop += 1;
        }

    }
    private string btnName() {
         name = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(name);
            return name;
    }

    public void selectOption() {
         nameEscenario = btnName();
        play.SetActive(true);
        SaveData();

    }

    private void SaveData()
    {
        Debug.Log("entre");
        DataBetweenScenes.instance.SetEscenario(int.Parse(name));
        Debug.Log("sali:" + DataBetweenScenes.instance.GetEscenario());
    }


    public void backMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void startGame()
    {
        SceneManager.LoadScene(name);//Ahí va la scene
    }

    private void addUI() {

        blocks.Add((GameObject)(defaultBlock));
        blocks.Add((GameObject)(bodegaBlock));
        blocks.Add((GameObject)(discoBlock));
        blocks.Add((GameObject)(playaBlock));
        blocks.Add((GameObject)(luchaBlock));


        selects.Add((GameObject)(defaultSelect));
        selects.Add((GameObject)(bodegaSelect));
        selects.Add((GameObject)(discoSelect));
        selects.Add((GameObject)(playaSelect));
        selects.Add((GameObject)(luchaSelect));



        texts.Add((Text)(defaultT));
        texts.Add((Text)(bodegaT));
        texts.Add((Text)(discoT));
        texts.Add((Text)(playaT));
        texts.Add((Text)(luchaT));

    }

}
