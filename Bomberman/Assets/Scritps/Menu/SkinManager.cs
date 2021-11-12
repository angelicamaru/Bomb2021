using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{

    DatabaseReference reference;
    private int idUser;
    private string nivel;
    private int escena;

    public Button[] nivelBTN;
    // Start is called before the first frame update
    void Start()
    {
        disableButtons();
        Debug.Log("hell");
        LoadData();
        chargeLevels();


    }

    public void chargeLevels()
    {
        Debug.Log("HOLA!");
        Debug.Log(idUser.ToString() + " " + idUser);
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
               
               int size = level.vestuario().Count;

               enableButtons(size);
           }
       });
    }

    void Update()
    {
       
 
       
    }


    public void enableButtons(int size) {
        Debug.Log(size);
        for (int i = 0; i < size; i++)
        {
          nivelBTN[i].interactable = true;
        }
    
    }

    public void disableButtons()
    {

        for (int i = 0; i < nivelBTN.Length; i++)
        {
            nivelBTN[i].interactable = false;
        }

    }

    public void LoadData()
    {
        idUser = DataBetweenScenes.instance.GetUserId();
    }

    public void buttonUno()
    {
        escena = 1;
    }

    public void buttonDos()
    {
        escena = 2;
  
    }

    public void buttonTres()
    {
        escena = 3;
  

    }

    public void SaveData()
    {
        Debug.Log("entre");
        DataBetweenScenes.instance.vestuario = escena;
        Debug.Log("sali:" + DataBetweenScenes.instance.GetVestuario());
    }

}
