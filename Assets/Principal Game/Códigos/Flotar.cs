
using UnityEngine;

public class Flotar : MonoBehaviour
{
    public float amplitud = 0.2f; 
    public float velocidad = 2f;  

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * velocidad) * amplitud;
        transform.position = posicionInicial + new Vector3(0, y, 0);
    }
}