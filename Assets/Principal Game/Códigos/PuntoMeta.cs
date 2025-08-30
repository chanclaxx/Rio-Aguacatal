
using UnityEngine;
using UnityEngine.SceneManagement;


public class PuntoMeta : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Verificamos si recolectó todos los elementos buenos
            if (ContadorElementos.instancia != null && 
                ContadorElementos.instancia.elementosBuenos >= ContadorElementos.instancia.totalElementosBuenos)
            {
                Debug.Log("¡Llegó a la meta con todos los elementos! Victoria 🚀");
                SceneManager.LoadScene("Victoria"); // 👈 asegúrate de que la escena se llame así
            }
            else
            {
                Debug.Log("No recolectó todo, no puede ganar aún ❌");
            }
        }
    }
}