using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LloverElementMalos : MonoBehaviour
{
    [Header("Prefabs de elementos malos")]
    public GameObject[] elementosMalos;     // Prefabs de elementos malos

    [Header("Puntos fijos de spawn")]
    public Transform[] puntosSpawn;         // Lugares donde pueden aparecer

    [Header("Tiempos de spawn (más rápido)")]
    public float tiempoMinSpawn = 1.5f;   // más rápido que antes
    public float tiempoMaxSpawn = 3f;     

    void Start()
    {
        StartCoroutine(LluviaInfinita());
    }

    IEnumerator LluviaInfinita()
    {
        while (true)
        {
            float espera = Random.Range(tiempoMinSpawn, tiempoMaxSpawn);
            yield return new WaitForSeconds(espera);

            // Elegir un elemento al azar
            int indexElemento = Random.Range(0, elementosMalos.Length);
            GameObject prefab = elementosMalos[indexElemento];

            // Elegir un punto fijo al azar
            int indexPunto = Random.Range(0, puntosSpawn.Length);
            Vector3 spawnPos = puntosSpawn[indexPunto].position;

            // Instanciar el objeto
            Instantiate(prefab, spawnPos, Quaternion.identity);
        }
    }
}