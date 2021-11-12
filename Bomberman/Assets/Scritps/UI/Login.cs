using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Extensions;
using Firebase.Database;
using Newtonsoft.Json;

public class Login : MonoBehaviour
{
    DatabaseReference reference;


    public Text email;
    public Text noRegistrado;
    public InputField displayP;
    public int loop;//idUser

 

    // Start is called before the first frame update
    void Start()
    {
        
         reference = FirebaseDatabase.DefaultInstance.RootReference;
        loop = -1;
       

    }


     // Update is called once per frame
     void Update()
     {

     }

     public void SubmmitUser(){


         /*.GetReference("usuario").Child("lis123")
       .GetValueAsync().ContinueWithOnMainThread(task => {

        */
         FirebaseDatabase.DefaultInstance
       .GetReference("usuarios")
       .GetValueAsync().ContinueWithOnMainThread(task => {
           if (task.IsFaulted)
           {
               // Handle the error...
               DataSnapshot snapshot = task.Result;
               Debug.Log("Error");
           }
           else if (task.IsCompleted)
           {
               DataSnapshot snapshot = task.Result;
              // Debug.Log("Success "+ snapshot.GetRawJsonValue());
               // Do something with snapshot...
              
               List<Usuario> users = JsonConvert.DeserializeObject< List < Usuario >> (snapshot.GetRawJsonValue());
       
               // List<Usuario> users = JsonUtility.FromJson<List<Usuario>>(snapshot.GetRawJsonValue());

               //validar si existe
               if (existeUser(users))
               {
                   //Sí existe
                  
                  // Debug.Log("Sii"+users[loop].email+loop);
                   SaveData();

                   cambioMenu();

               }
               else {

                   //No existe
                   Debug.Log("NO :(");
                   noRegistrado.text = "Usuario NO registardo";


               }

               //Reenviarlo si existe || link de registro

            
           }
       });
     }

    private bool existeUser(List<Usuario> users) {
        bool existe = false;
        loop = -1;

        foreach (Usuario item in users)
        {
            loop ++;
            if (item.email.Equals(email.text) && item.password.Equals(displayP.text)) {
              
               
                existe = true;
                break;
              }
        }

        return existe;
    
    }

    public void cambioRegistro() {
        SceneManager.LoadScene("Registro");
    }

    public void cambioMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void SaveData() {
    //  Debug.Log("entre");
        DataBetweenScenes.instance.SetUserId(loop);
     //   Debug.Log("sali:"+ DataBetweenScenes.instance.GetUserId());
    }

 
}
