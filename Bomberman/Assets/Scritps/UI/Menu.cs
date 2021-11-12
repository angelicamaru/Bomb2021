using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
 
    private int idUser;

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadData() {
        idUser = DataBetweenScenes.instance.GetUserId();
    }

    public void cambioLogin()
    {
        SceneManager.LoadScene("Login");
    }

    public void play()
    {
        SceneManager.LoadScene("Escenarios");
    }

    

}
