using UnityEngine;

public class ElementoBueno : MonoBehaviour
{
       void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ContadorElementos.instancia.SumarElemento();
            Destroy(gameObject); // Desaparece el objeto
        }
    }
}