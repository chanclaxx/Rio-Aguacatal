
using UnityEngine;

public class BanderaAnim : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        // Al iniciar, la bandera siempre empieza en Idle
        anim.Play("Idle");
    }

    void Update()
    {
        // Ejemplo: si se presiona espacio, cambia a otra animación llamada "Victoria"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("Victoria");
        }
    }
}