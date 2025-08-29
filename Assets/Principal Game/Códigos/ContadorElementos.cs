using UnityEngine;
using TMPro;
using System.Collections;

public class ContadorElementos : MonoBehaviour
{
public static ContadorElementos instancia;
    public int elementosBuenos = 0;                  // Elementos recolectados
    public int totalElementosBuenos = 6;            // Total de elementos a recolectar
    public TextMeshProUGUI textoContador;           // Referencia al texto en UI

    private Vector3 escalaOriginal;

    void Awake()
    {
        if (instancia == null) instancia = this;
        else Destroy(gameObject);

        escalaOriginal = transform.localScale;
    }

    void Start()
    {
        ActualizarUI(); // Asegura que el texto se vea al iniciar
    }

    public void SumarElemento()
    {
        elementosBuenos++;
        ActualizarUI();
        StartCoroutine(AnimarTexto());
    }

    public void Reiniciar()
    {
        elementosBuenos = 0;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (textoContador != null)
            textoContador.text = elementosBuenos + "/" + totalElementosBuenos;
        else
            Debug.LogWarning("TextoContador no está asignado en el inspector.");
    }

    IEnumerator AnimarTexto()
    {
        transform.localScale = escalaOriginal * 1.2f;
        if (textoContador != null)
            textoContador.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);
        transform.localScale = escalaOriginal;
        if (textoContador != null)
            textoContador.color = Color.green;
    }
}
