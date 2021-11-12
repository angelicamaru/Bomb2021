using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    PlayerController player;
    public Collider2D bodyCollider;
    public LayerMask Players;
    public Animator animator;
    public GameObject person, person2, person3;
    int kill = 0;
    public bool vertical;
     Vector2 movimiento;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType(typeof(PlayerController)) as PlayerController;
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        movimiento.x = x;
        movimiento.y = y;
        if(vertical){
            x = 0;
        }else{
            y = 0; 
        }
        animator.SetFloat("Horizontal", x); 
        animator.SetFloat("Vertical", y*-1);
        animator.SetFloat("Speed", movimiento.sqrMagnitude);
        if(kill ==  0){
            if(bodyCollider.IsTouchingLayers(Players)){
                person.transform.position = new Vector3(5,1,0);
                person2.transform.position = new Vector3(5,1,0);
                person3.transform.position = new Vector3(5,1,0);
                player.die();
                kill++;
            }
        }else{
            if(!bodyCollider.IsTouchingLayers(Players)){
                kill = 0;
            }
        }

        
    }
  
}
