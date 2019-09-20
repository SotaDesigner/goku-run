using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBolasdragon : MonoBehaviour
{

    public float tiempoEntreSpawns;
    public GameObject obstaculoPrefab;
    public GameObject obstaculoPrefab2;
    public GameObject obstaculoPrefab3;
    public GameObject obstaculoPrefab4;
    public GameObject obstaculoPrefab5;
    public GameObject obstaculoPrefab6;
    public GameObject obstaculoPrefab7;
   int contador = 0;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 16.0f, tiempoEntreSpawns);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
       if (contador % 7 == 0)
        {
            Vector3 position = new Vector3(-0.5f, Random.Range(-7.42f, -6.24f), 0);
            Instantiate(obstaculoPrefab, transform.position + position, Quaternion.identity);
        }
        else if (contador % 7 == 1)
        {
            Vector3 position = new Vector3(-0.5f, Random.Range(-7.42f, -6.24f), 0);
            Instantiate(obstaculoPrefab2, transform.position + position, Quaternion.identity);
        }
        else if (contador % 7 == 2)
        {
            Vector3 position = new Vector3(-0.5f, Random.Range(-7.42f, -6.24f), 0);
            Instantiate(obstaculoPrefab3, transform.position + position, Quaternion.identity);
        }
        else if (contador % 7 == 3)
        {
            Vector3 position = new Vector3(-0.5f, Random.Range(-7.42f, -6.24f), 0);
            Instantiate(obstaculoPrefab4, transform.position + position, Quaternion.identity);
        }
        else if (contador % 7 == 4)
        {
            Vector3 position = new Vector3(-0.5f, Random.Range(-7.42f, -6.24f), 0);
            Instantiate(obstaculoPrefab5, transform.position + position, Quaternion.identity);
        }
        else if (contador % 7 == 5)
        {
            Vector3 position = new Vector3(-0.5f, Random.Range(-7.42f, -6.24f), 0);
            Instantiate(obstaculoPrefab6, transform.position + position, Quaternion.identity);
        }
        else if (contador % 7 == 6)
        {
            Vector3 position = new Vector3(-0.5f, Random.Range(-7.42f, -6.24f), 0);
            Instantiate(obstaculoPrefab7, transform.position + position, Quaternion.identity);
        }
        contador++;
    }
}


