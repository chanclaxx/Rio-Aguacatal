using UnityEngine;
using UnityEngine.SceneManagement;

public class PuntoMuerte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡El jugador cayó en el punto de muerte!");
            SceneManager.LoadScene("Game Over");
        }
    }
}