using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    public Text ScoreText;
    void Start()
    {
        score=0;
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag=="Moneda"){
            score++;
            //Debug.Log(score);
            ScoreText.text= "Score "+score;
           
        }
    }
    
}
