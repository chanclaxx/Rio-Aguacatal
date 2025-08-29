using UnityEngine.SceneManagement;
using UnityEngine;

public class tiempoBarra : MonoBehaviour
{
      public float tiempoTotal = 100f;   // Tiempo inicial
    private float tiempoRestante;

    public Transform barra;            // La barra que representa el tiempo
    private Vector3 escalaInicial;
    private Vector3 posicionInicial;

    private bool tiempoDetenido = false;

    void Start()
    {
        tiempoRestante = tiempoTotal;
        escalaInicial = barra.localScale;
        posicionInicial = barra.localPosition;
    }

    void Update()
    {
        if (tiempoDetenido) return; // Si ya se detuvo, no hacer nada

        if (tiempoRestante > 0f)
        {
            tiempoRestante -= Time.deltaTime;

            float porcentaje = Mathf.Clamp01(tiempoRestante / tiempoTotal);
            float nuevaEscalaX = escalaInicial.x * porcentaje;

            // 🔄 Invertido: de derecha a izquierda
            barra.localScale = new Vector3(nuevaEscalaX, escalaInicial.y, escalaInicial.z);

            float diferencia = (escalaInicial.x - nuevaEscalaX) / 2f;
            barra.localPosition = new Vector3(posicionInicial.x - diferencia, posicionInicial.y, posicionInicial.z);
        }
        else
        {
            barra.localScale = new Vector3(0, escalaInicial.y, escalaInicial.z);
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("¡Tiempo terminado!");
        tiempoDetenido = true;

        // 🔄 Cargar la escena de Game Over
        SceneManager.LoadScene("Game Over");
    }

    public void DetenerTiempoPorVictoria()
    {
        tiempoDetenido = true; 
        Debug.Log("¡Ha llegado a salvo!");

        // 🔄 Cargar la escena de Victoria
        SceneManager.LoadScene("Victoria");
    }

    public void AgregarTiempo(float segundos)
    {
        tiempoRestante += segundos;
        tiempoRestante = Mathf.Min(tiempoRestante, tiempoTotal);
        Debug.Log("Tiempo aumentado en " + segundos + " segundos.");
    }
}