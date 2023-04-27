using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JhonMov : MonoBehaviour
{
    // Start is called before the first frame update
    //sonido bala 
    public AudioClip Sound;
    public AudioClip soundBala;
    //s
    public float Speed;
    public float JumpForce;
    public GameObject BulletPrefab;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    //vida 
    private int health=5;
    //balascantidad
    public TMPro.TextMeshProUGUI textContadorBalas;
    public int cantBalas=0;
    //
    void Start()
    {
        Rigidbody2D= GetComponent<Rigidbody2D>();
        Animator= GetComponent<Animator>();
        //SonidoSalto
       // Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
        //s
    }

    // Update is called once per frame
    void Update()
    {
         Horizontal= Input.GetAxisRaw("Horizontal");
         if(Horizontal<0.0f)transform.localScale= new Vector3(-1.0f,1.0f,1.0f);
         else if(Horizontal>0.0f)transform.localScale= new Vector3(1.0f,1.0f,1.0f);
         Animator.SetBool("running",Horizontal!=0.0f);
         Debug.DrawRay(transform.position, Vector3.down*0.1f, Color.blue);
         if(Physics2D.Raycast(transform.position, Vector3.down,0.1f)){
            Grounded= true;
         }
         else Grounded= false;
         if(Input.GetKeyDown(KeyCode.W)&& Grounded){
            Jump();
         }
         if(Input.GetKey(KeyCode.Space)&& Time.time>LastShoot+0.25f){
            if(cantBalas>0){
                Shoot();
            }
            LastShoot= Time.time;
         }
    //balascant
    textContadorBalas.text=cantBalas.ToString();
    //
    }
    //balascant
    private void OnTriggerEnter2D(Collider2D collis){
        if(collis.gameObject.CompareTag("Balas")){
            Destroy(collis.gameObject);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(soundBala);
            cantBalas+=5;
        }
    }
    private void Jump(){
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
        Rigidbody2D.AddForce(Vector2.up* JumpForce);
    }
    private void Shoot(){
        Vector3 direction;
        if(cantBalas>0){
        if(transform.localScale.x == 1.0f)direction= Vector3.right;
        else direction = Vector2.left;
        GameObject bullet = Instantiate(BulletPrefab, transform.position+direction*0.1f, Quaternion.identity);
        bullet.GetComponent<BalletScript>().SetDirection(direction);
        cantBalas-=1;
        }
        //restar municion
        else cantBalas-=1;
    }
    private void FixedUpdate(){
        Rigidbody2D.velocity= new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
    public void Hit(){
        health= health-1;
        if(health==0) Destroy(gameObject);
    }
}
