
using UnityEngine;
using UnityEngine.SceneManagement;


public class PuntoMeta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Buscar el script de la barra de tiempo y detenerla por victoria
            tiempoBarra barra = FindObjectOfType<tiempoBarra>();
            if (barra != null)
            {
                barra.DetenerTiempoPorVictoria();
            }
        }
    }
}
