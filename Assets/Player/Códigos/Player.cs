using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        Debug.Log("Reiniciando juego...");

     
        Scene escenaActual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escenaActual.name);
    }
}