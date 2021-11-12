using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Usuario 
{

    public string name;
    public string email;
    public string password;
    public string username;
    public int asesinatos;
    public int nivel;
    public int score;


    public Usuario(string _name, string _email, string _password, string _username, int _asesinatos, int _nivel,int _score)
    {

        email = _email;
        name = _name;
        password = _password;
        username = _username;
        asesinatos = _asesinatos;
        nivel = _nivel;
        score = _score;

    }

   


}
