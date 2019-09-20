using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Declaraciones//
    Rigidbody2D myRigidbody;
    public float speed = 10.0f;
    int point = 0;
    int energia = 0;
    int bolaDragon = 0;
    public Text scoreText;
    public Text bolasText;
    public Slider scoreSlider;
    public AudioSource musica;
    //GAME OBJECT
    public GameObject gameOverMenu;
    public GameObject textoDisparoSencillo;
    public GameObject textoUltimate;
    public GameObject disparoSencillo;
    public GameObject ultimate;
    public GameObject SonidoKi;
    // Use this for initialization
    void Start()
    {
        Vector2 velocidadHaciaLaDerecha;

        velocidadHaciaLaDerecha = Vector2.right * 0.0f;
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.velocity = velocidadHaciaLaDerecha;
        //Disparo();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began)
        {
            Vector2 newVelocity;

            newVelocity = Vector2.up * speed;

            myRigidbody.velocity = newVelocity;

            FindObjectOfType<AudioManager>().Play("Salto");
        }

    }
    public void DisparoSencillo()
    {
        if (Input.GetMouseButtonUp(0) || Application.platform == RuntimePlatform.Android)
        {
            Vector3 position = new Vector3(2, 0, 0);
            Instantiate(disparoSencillo, transform.position + position, Quaternion.identity);
            energia = (energia - 5);
            FindObjectOfType<AudioManager>().Play("DisparoNormal");
            if (energia < 5)
            {
                textoDisparoSencillo.SetActive(false);
                FindObjectOfType<AudioManager>().Pause("Ki5Energia");
            }
            textoUltimate.SetActive(false);
            scoreSlider.value = energia;
        }
    }
    public void DisparoUltimate()
    {
        if (Input.GetMouseButtonUp(0) || Application.platform == RuntimePlatform.Android)
        {
            Vector3 position = new Vector3(0, 0, 0);
            Instantiate(ultimate, transform.position + position, Quaternion.identity);
            energia = (energia - 10);
            textoUltimate.SetActive(false);
            FindObjectOfType<AudioManager>().Play("DisparoUltimate");
            scoreSlider.value = energia;
            FindObjectOfType<AudioManager>().Pause("Ki10Energia");
            FindObjectOfType<AudioManager>().Pause("Ki5Energia");
        }
    }

    private void MostrarSiEnergiaSuficiente()
    {
        if (energia == 5)
        {
            textoDisparoSencillo.SetActive(true);
            FindObjectOfType<AudioManager>().Play("KiInicio");
            Invoke("SonidoEnergiaMediaBucle", 1.4f);
        }
        if (energia == 10)
        {
            textoUltimate.SetActive(true);
            FindObjectOfType<AudioManager>().Play("KiInicioUltimate");
            Invoke("SonidoEnergiaMaximaBucle", 1.4f);
            FindObjectOfType<AudioManager>().Pause("Ki5Energia");
        }
        if (energia < 5)
        {
            textoDisparoSencillo.SetActive(false);
            textoUltimate.SetActive(false);
            FindObjectOfType<AudioManager>().Pause("Ki5Energia");
            FindObjectOfType<AudioManager>().Pause("Ki10Energia");
        }
        if (energia < 10)
        {
            textoUltimate.SetActive(false);
            FindObjectOfType<AudioManager>().Pause("Ki10Energia");
        }
    }
    public void SonidoEnergiaMediaBucle()
    {
        FindObjectOfType<AudioManager>().Play("Ki5Energia");
    }
    public void SonidoEnergiaMaximaBucle()
    {
        FindObjectOfType<AudioManager>().Play("Ki10Energia");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); 
        gameOverMenu.SetActive(true);
        FindObjectOfType<AudioManager>().Play("MuerteJugador");
        musica.Pause();
        FindObjectOfType<AudioManager>().Pause("Ki5Energia");
        FindObjectOfType<AudioManager>().Pause("Ki10Energia");
        if (point > PlayerPrefs.GetInt("Max.Score")) 
        {
            PlayerPrefs.SetInt("Max.Score", point);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            point++;
            if (scoreText != null)
            {
                scoreText.text = point.ToString();
            }
            else
            {
                print(point);
            }
        }
        if (other.tag == "Orbe")
        {
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Orbe");
            if (energia < 10)
            {
                energia++;
            }
            scoreSlider.value = energia;
            MostrarSiEnergiaSuficiente();
        }
        if (other.tag == "BolaDragon")
        {
            Destroy(other.gameObject);
            bolaDragon++;
            if (bolasText != null)
            {
                FindObjectOfType<AudioManager>().Play("Bola");
                bolasText.text = bolaDragon.ToString("Bolas de dragon: " + bolaDragon);
            }
        }
    }
}
