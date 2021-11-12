using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {
    void Start (){

    }
    void Update (){

    }

    public void empezarJuego(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }
    public void cerrarJuego (){
       SaveData();
        SceneManager.LoadScene("Registro");
    }

    public void play()
    {
        SceneManager.LoadScene("Escenarios");
    }

    private void SaveData()
    {
        //  Debug.Log("entre");
        DataBetweenScenes.instance.SetVestuario(0);
        DataBetweenScenes.instance.SetEscenario(0);

        //   Debug.Log("sali:"+ DataBetweenScenes.instance.GetUserId());
    }

}