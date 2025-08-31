using UnityEngine;
using TMPro;
using System.Collections;

public class NPCDialogo : MonoBehaviour
{
    [Header("Configuración del NPC")]
    [TextArea] public string mensaje;          
    public GameObject panelDialogo;            
    public TextMeshProUGUI textoDialogo;       
    public float velocidadEscritura = 0.05f;   
    public Transform puntoCabeza;              
    public float distanciaActivacion = 3f;     // 🔹 Distancia máxima para activar diálogo

    private bool jugadorCerca = false;
    private Coroutine escribiendo;
    private Camera camara;
    private Transform jugador;

    void Start()
    {
        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        camara = Camera.main;
        jugador = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (jugador != null)
        {
            float distancia = Vector2.Distance(jugador.position, transform.position);

            if (distancia <= distanciaActivacion && !jugadorCerca)
            {
                jugadorCerca = true;
                MostrarDialogo();
            }
            else if (distancia > distanciaActivacion && jugadorCerca)
            {
                jugadorCerca = false;
                OcultarDialogo();
            }
        }

        if (panelDialogo != null && panelDialogo.activeSelf && puntoCabeza != null)
        {
            Vector3 posicionPantalla = camara.WorldToScreenPoint(puntoCabeza.position);
            panelDialogo.transform.position = posicionPantalla;
        }
    }

    void MostrarDialogo()
    {
        if (panelDialogo != null && textoDialogo != null)
        {
            if (escribiendo != null) StopCoroutine(escribiendo);
            panelDialogo.SetActive(true);
            escribiendo = StartCoroutine(EfectoEscritura(mensaje));
        }
    }

    void OcultarDialogo()
    {
        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        if (escribiendo != null) StopCoroutine(escribiendo);
    }

    IEnumerator EfectoEscritura(string texto)
    {
        textoDialogo.text = "";
        foreach (char letra in texto)
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(velocidadEscritura);
        }
    }
}