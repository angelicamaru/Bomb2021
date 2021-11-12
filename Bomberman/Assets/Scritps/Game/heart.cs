using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{

    public void dieHeart(){

        Debug.Log("aqui");
        gameObject.SetActive(false);
    }
}
