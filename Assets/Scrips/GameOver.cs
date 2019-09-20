using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public Text textoMaxScore;
    AudioSource emisorSonido;
    public AudioClip sonidoBoton;
    public float volumenSonido;
    public float volumenBoton;

    void Start()
    {
        textoMaxScore.text = PlayerPrefs.GetInt("Max.Score").ToString();

        emisorSonido = GetComponent<AudioSource>();
        emisorSonido.volume = volumenSonido;
    }

    public void Play()
    {
        Invoke("cambiarEscenaDeJuego", 0.5f);
        emisorSonido.volume = volumenBoton;
        emisorSonido.PlayOneShot(sonidoBoton);
    }
    public void Exist()
    {
        Invoke("cambiarEscenaDePlay", 0.5f);
        emisorSonido.volume = volumenBoton;
        emisorSonido.PlayOneShot(sonidoBoton);
    }
    public void cambiarEscenaDeJuego()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void cambiarEscenaDePlay()
    {
        SceneManager.LoadScene("Play");
    }

}
