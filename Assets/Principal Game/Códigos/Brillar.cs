
using UnityEngine;

public class Brillar : MonoBehaviour
{
    public float escalaExtra = 0.1f;
    public float velocidad = 2f;

    private Vector3 escalaOriginal;

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        float factor = 1 + Mathf.Sin(Time.time * velocidad) * escalaExtra;
        transform.localScale = escalaOriginal * factor;
    }
}