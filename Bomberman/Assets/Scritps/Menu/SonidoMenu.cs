using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoMenu : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip soundMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundButton(){
        sound.clip=soundMenu;
        sound.enabled=false;
        sound.enabled=true;
    }
}
