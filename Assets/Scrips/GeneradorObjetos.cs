using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetos : MonoBehaviour
{

    public float tiempoEntreSpawns;
    public GameObject obstaculoPrefab;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, tiempoEntreSpawns);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
        Vector3 position = new Vector3(0, Random.Range(-0.93f, 1.96f), 0);
        Instantiate(obstaculoPrefab, transform.position + position, Quaternion.identity);
    }
}

