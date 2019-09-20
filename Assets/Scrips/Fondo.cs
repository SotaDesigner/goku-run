using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{

    public float velodiadScroll = 5;
    Material miMaterial;
    // Use this for initialization
    void Start()
    {
        miMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        miMaterial.mainTextureOffset = miMaterial.mainTextureOffset + Vector2.right * velodiadScroll * Time.deltaTime;
    }
}
