using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : MonoBehaviour
{

    //Declaración
    public float velocidad = -5.0f;

    // Use this for initialization
    void Start()
    {
        Destruir();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * velocidad * Time.deltaTime;
    }
    void Destruir()
    {
        Destroy(gameObject, 6);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}
