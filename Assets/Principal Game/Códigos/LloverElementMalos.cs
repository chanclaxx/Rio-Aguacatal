using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LloverElementMalos : MonoBehaviour
{
   public GameObject[] elementosMalos;   // Tus 5 elementos malos
    public Transform[] posiciones;        // Las posiciones en escena donde aparecerán
    public float intervaloMin = 0.5f;     // Tiempo mínimo entre caídas
    public float intervaloMax = 2f;       // Tiempo máximo entre caídas

    void Start()
    {
        StartCoroutine(GenerarElementos());
    }

    IEnumerator GenerarElementos()
    {
        while (true) // loop infinito
        {
            for (int i = 0; i < elementosMalos.Length; i++)
            {
                // Instancia el elemento en la posición de escena
                Instantiate(elementosMalos[i], posiciones[i].position, Quaternion.identity);

                // Espera un tiempo aleatorio antes de generar el siguiente
                float delay = Random.Range(intervaloMin, intervaloMax);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}