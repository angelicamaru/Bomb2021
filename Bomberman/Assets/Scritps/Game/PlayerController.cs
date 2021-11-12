using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public PlayerController skin1, skin2, skin3;
    int vidas = 3;
    int playersKill = 0;
    private Rigidbody2D rb2d;
    public Animator animator;
    public GameOverScreen GameOverScreen;
    public Win WinScreen;
    public Collider2D bodyCollider;
    public LayerMask finish; 
    public heart heart1, heart2, heart3;

    public int gamer;

    int score = 0;
    

    Vector2 movimiento;
    // Start is called before the first frame update
    void Start()
    {
        //aqui llamar a lafuncion que me da el señalado
        LoadData();
        int selected = gamer;
        if(selected == 2){
            skin3.gameObject.SetActive(true);
            skin1.gameObject.SetActive(false);
        }else if(selected == 3){
            skin2.gameObject.SetActive(true);
            skin1.gameObject.SetActive(false);
        }
        rb2d = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(5,1,0);
        
    }

    public void LoadData()
    {
        gamer = DataBetweenScenes.instance.GetVestuario();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movimiento.x = x;
        movimiento.y = y;
        animator.SetFloat("Horizontal", x); 
        animator.SetFloat("Vertical", y);
        animator.SetFloat("Speed", movimiento.sqrMagnitude);
        

        if(Mathf.Abs(x) >= Mathf.Abs(y)){
            y=0;
        }else if(Mathf.Abs(y) >= Mathf.Abs(x)){
            x = 0;
        }
        Vector2 movement = new Vector2(x , y) * speed ;
        rb2d.velocity = movement;
        if(bodyCollider.IsTouchingLayers(finish)){
            Destroy(gameObject);
            WinScreen.SetUp(score+500);
        }
        
    }

    public void die(){
        if(vidas == 0){
            transform.position = new Vector3(5,1,0);
            Destroy(gameObject);
            GameOverScreen.SetUp(playersKill*100);

        }else{
            transform.position = new Vector3(5,1,0);
            if(vidas==3){
                heart3.dieHeart();
            }else if(vidas == 2){
                heart2.dieHeart();
            }else{
                heart1.dieHeart();
            }
            vidas--;
        }
        
    }

    public void kill(){
        playersKill++;
        score = score + 100;
    }

    
}
