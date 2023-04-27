using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*public int PuntosTotales{get{return puntosTotales;}}
    private int puntosTotales;
    public HUD hud;
    private int vidas =3;

    public void  SumarPuntos(int puntosSumar){
       puntosTotales+= puntosSumar;
       hud.ActualizarPuntos(puntosTotales);
       Debug.Log(puntosTotales);
    }
    public void PerderVida(){
        vidas-=1;
        hud.DesactivarVida(vidas);
    }*/
    public AudioClip Sound;
    public static GameManager Instance { get; private set; }
	public HUD hud;
    public int PuntosTotales {get; private set;}
	private int vidas = 3;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }
    }
    public void SumarPuntos(int puntosASumar)
    {
        PuntosTotales += puntosASumar;
		hud.ActualizarPuntos(PuntosTotales);
    }
	public void PerderVida() {
		vidas -= 1;
		if(vidas == 0)
		{
			// Reiniciamos el nivel.
			SceneManager.LoadScene(0);
		}
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
		hud.DesactivarVida(vidas);
	}
	public bool RecuperarVida() {
		if (vidas == 3)
		{
			return false;
		}
		hud.ActivarVida(vidas);
		vidas += 1;
		return true;
	}
}
