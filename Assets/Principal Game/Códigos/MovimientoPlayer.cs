using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    // Animación
    private Animator anim;

    [Header("Movimiento")]
    private float horizontal;
    public float velocidad = 5f;
    private bool mirandoDerecha = true;

    [Header("Salto")]
    public float speedSalto = 8f;
    public Transform checkpiso;
    public LayerMask layerPiso;

    private void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        // Movimiento horizontal (A-D o flechas)
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0)
        {
            transform.GetChild(0).localScale = new Vector3(-1, 1, 0);
        }
        else if (horizontal > 0) transform.GetChild(0).localScale = new Vector3(1, 1);

        //Aplicar animacion
        anim.SetBool("run", horizontal != 0);

        // Salto con Space
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, speedSalto);
        }

        voltear();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * velocidad, rb.linearVelocity.y);
    }

    private void voltear()
    {
        if ((mirandoDerecha && horizontal < 0f) || (!mirandoDerecha && horizontal > 0f))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(checkpiso.position, 0.2f, layerPiso);
    }

    // Opcional: dibujar el círculo de detección del suelo en la escena
    private void OnDrawGizmos()
    {
        if (checkpiso != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(checkpiso.position, 0.2f);
        }
    }
}