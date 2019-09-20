using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Text textoMaxScore;
    AudioSource emisorAudio;
    public AudioClip sonidoBoton;
    public float volumenBoton;

    public void Start()
    {
        textoMaxScore.text = "Max.Score: " + PlayerPrefs.GetInt("Max.Score").ToString();
        emisorAudio = GetComponent<AudioSource>();
    }
    public void Play()
    {
        Invoke("comenzarPlay", 0.5f);
        emisorAudio.volume = volumenBoton;
        emisorAudio.PlayOneShot(sonidoBoton);
    }
    public void Exist()
    {
        Invoke("salir", 0.5f);
        emisorAudio.volume = volumenBoton;
        emisorAudio.PlayOneShot(sonidoBoton);
        print("he pulsado salir");
    }
    public void comenzarPlay()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void salir()
    {
        Application.Quit();
    }
}
