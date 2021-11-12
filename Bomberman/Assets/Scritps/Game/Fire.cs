using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.3f);
        player = GameObject.FindObjectOfType(typeof(PlayerController)) as PlayerController;
    }

    void Update(){
        //Animation
    }

    public void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.gameObject.GetComponent<Fire>() == null){
            Debug.Log("fire");
            if(collision.gameObject.GetComponent<PlayerController>() != null){
                Debug.Log("player");
                player.die();
            }else{
                if(collision.gameObject.GetComponent<Monster>() != null){

                    player.kill();
                }
                Destroy(collision.gameObject);
            }
            
            
        }
        if(collision.gameObject.GetComponent<Bomb>() != null){
            collision.gameObject.GetComponent<Bomb>().Explode();
        }
  
    }
}
