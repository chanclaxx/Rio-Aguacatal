using UnityEngine;

public class ElementoBueno : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisión con: " + other.name);
        if (other.CompareTag("Player"))
        {
            ContadorElementos.instancia.SumarElemento();
            Destroy(gameObject);
        }
    }
}