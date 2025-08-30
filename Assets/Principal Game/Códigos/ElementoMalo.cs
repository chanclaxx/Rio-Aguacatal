using System.Collections;
using UnityEngine;

public class ElementoMalo : MonoBehaviour
{
    [Header("Configuración de caída")]
    public float velocidadCaida = 0.5f;           // Velocidad lenta
    public float gravedadRigidbody = 0.2f;        // Si usa Rigidbody2D

    [Header("Parpadeo al acercarse al Player")]
    public float distanciaParpadeo = 3f;          // A 3 de distancia
    public float tiempoParpadeo = 0.2f;

    [Header("Daño al Player")]
    public int daño = 1;

    private SpriteRenderer spriteRenderer;
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.gravityScale = gravedadRigidbody;
    }

    void Update()
    {
        // Movimiento si no hay Rigidbody
        if (rb == null)
        {
            transform.position += Vector3.down * velocidadCaida * Time.deltaTime;
        }

        // Parpadeo al estar cerca
        if (player != null && Vector3.Distance(transform.position, player.position) < distanciaParpadeo)
        {
            if (!IsInvoking("Parpadear"))
                InvokeRepeating("Parpadear", 0f, tiempoParpadeo);
        }
        else
        {
            CancelInvoke("Parpadear");
            if (spriteRenderer != null)
                spriteRenderer.color = Color.white;
        }
    }

    void Parpadear()
    {
        if (spriteRenderer != null)
            spriteRenderer.color = spriteRenderer.color == new Color(1f, 0f, 0f, 1f) 
                                   ? Color.white 
                                   : new Color(1f, 0f, 0f, 1f); // rojo intenso
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisión detectada con: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Colisión con el Player!");
            Player playerScript = other.GetComponent<Player>();
            if (playerScript != null)
                playerScript.RecibirDaño(daño);

            Destroy(gameObject);
        }
    }
}
    