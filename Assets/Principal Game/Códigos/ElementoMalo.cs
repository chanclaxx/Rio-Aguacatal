using System.Collections;
using UnityEngine;

public class ElementoMalo : MonoBehaviour
{
   public float velocidadCaida = 2f;         // Velocidad de caída
    public float distanciaParpadeo = 2f;      // Distancia al Player para parpadear
    public float tiempoParpadeo = 0.2f;       // Intervalo de parpadeo
    private SpriteRenderer spriteRenderer;
    private Transform player;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Caer hacia abajo
        transform.position += Vector3.down * velocidadCaida * Time.deltaTime;

        // Parpadeo si está cerca del Player
        if (Vector3.Distance(transform.position, player.position) < distanciaParpadeo)
        {
            if (!IsInvoking("Parpadear"))
                InvokeRepeating("Parpadear", 0f, tiempoParpadeo);
        }
        else
        {
            CancelInvoke("Parpadear");
            if(spriteRenderer != null)
                spriteRenderer.color = Color.white;
        }
    }

    void Parpadear()
    {
        if (spriteRenderer != null)
            spriteRenderer.color = spriteRenderer.color == Color.red ? Color.white : Color.red;
    }
}