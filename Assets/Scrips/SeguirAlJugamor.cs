using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirAlJugamor : MonoBehaviour
{

    public GameObject player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicionDelJugador;

        posicionDelJugador = player.transform.position;
        posicionDelJugador.y = 0.0f;
        posicionDelJugador.z = -10.0f;

        transform.position = posicionDelJugador;
    }
}
