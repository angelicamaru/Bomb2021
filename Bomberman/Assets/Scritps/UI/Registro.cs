using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Firebase;
using Firebase.Database;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
using Firebase.Extensions;

public class Registro : MonoBehaviour
{
   
   DatabaseReference reference;


    public Text nameUser;
    public Text nameReal;
    public Text email;
    public InputField displayP;
    public int nivel;


    // Start is called before the first frame update
    void Start()
    {


     reference = FirebaseDatabase.DefaultInstance.RootReference;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReadStringInput()
    {
       // Debug.Log(nameUser.text+"hello"+ displayP.text);
       
    }

    public void SubmitRegistroUser() {

        Usuario user = new Usuario(nameReal.text, email.text, displayP.text, nameUser.text, 0, 1,0);

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
            //  Debug.Log("Success " + snapshot.GetRawJsonValue());
              // Do something with snapshot...

              List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(snapshot.GetRawJsonValue());
              usuarios.Add(user);
             
              string json = JsonConvert.SerializeObject(usuarios);
           //   Debug.Log(json);
              reference.Child("usuarios").SetRawJsonValueAsync(json);

          }
      });
       
    

   


    }

    public void cambioLogin()
    {
                SceneManager.LoadScene("Login");
    }


    public void cambioMenu()
    {
        SceneManager.LoadScene("Menu");
    }



}
