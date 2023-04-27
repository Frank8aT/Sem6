using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    public AudioClip Sound;
    void Start(){

    }
    void update(){

    }
    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.tag=="Player")
        {
            Destroy(this.gameObject);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);   
        }
    }
}
