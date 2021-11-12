using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPAtrol : MonoBehaviour
{
    public float walkSpeed, range;
    private float distToPlayer;
    public bool vertical;

    [HideInInspector]
    public bool mustPatrol;

    public Rigidbody2D rb;
    public Collider2D bodyCollider;
    public LayerMask groundLayer; 
    public LayerMask startLayer; 
    public Transform player; 
    
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol){
            Patrol();
        }

        /*distToPlayer = Vector2.Distance(transform.position, player.position);
        if(distToPlayer <= range){
            if(vertical){
                if((player.position.y > transform.position.y && transform.localScale.y < 0) || (player.position.y < transform.position.y && transform.localScale.y > 0)){
                    Flip();
                }
                rb.velocity = new Vector2( rb.velocity.x, walkSpeed * Time.fixedDeltaTime);

            }else{
                if((player.position.x > transform.position.x && transform.localScale.x < 0) || (player.position.x < transform.position.x && transform.localScale.x > 0)){
                    Flip();
                }
                rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
            }
            
        }*/

        

    }

    void Patrol(){
        if(bodyCollider.IsTouchingLayers(groundLayer) || bodyCollider.IsTouchingLayers(startLayer)){
            Flip();
        }
        if(vertical){
            rb.velocity = new Vector2( rb.velocity.x, walkSpeed * Time.fixedDeltaTime);
        }else{
            rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }
        
    }

    void Flip(){
        mustPatrol = false;
        if(vertical){
            transform.localScale = new Vector2(transform.localScale.x  * -1, transform.localScale.y);
        }else{
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        walkSpeed *= -1;
        mustPatrol = true;
        
    }

}

