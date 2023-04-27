using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip Sound;
    public int valor=1;
    public GameManager gameManager;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player"))
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
            gameManager.SumarPuntos(valor);
            Destroy(this.gameObject);
        }
        Debug.Log("Collision");
        //bala


        //
    }
}
