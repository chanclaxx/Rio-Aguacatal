using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [System.Serializable]
    public class CapaParallax
    {
        public Transform capa;          // El sprite o fondo
        [Range(0f, 1f)] public float velocidad; // Qué tan rápido se mueve
    }

    [SerializeField] private Transform camara;  
    [SerializeField] private CapaParallax[] capas;  

    private Vector3 ultimaPosCamara;

    void Start()
    {
        if (camara == null)
            camara = Camera.main.transform;

        ultimaPosCamara = camara.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovimiento = camara.position - ultimaPosCamara;

        // Mueve todas las capas
        foreach (var c in capas)
        {
            if (c.capa != null)
            {
                c.capa.position += new Vector3(deltaMovimiento.x * c.velocidad,
                                               deltaMovimiento.y * c.velocidad,
                                               0);
            }
        }

        ultimaPosCamara = camara.position;
    }
}