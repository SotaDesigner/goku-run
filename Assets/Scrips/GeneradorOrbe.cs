using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorOrbe : MonoBehaviour
{

    public float tiempoEntreSpawns;
    public GameObject obstaculoPrefab;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 1.0f, tiempoEntreSpawns);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
        Vector3 position = new Vector3(0, Random.Range(-6.0f, 2.0f), 0);
        Instantiate(obstaculoPrefab, transform.position + position, Quaternion.identity);
    }
}
