using System.Collections;
using UnityEngine;
using TMPro; 

public class BtnPanel : MonoBehaviour
{
    public float velocidad = 0.05f; 
    private TextMeshProUGUI textoTMP;
    private string textoCompleto;

    private void Awake()
    {
        textoTMP = GetComponent<TextMeshProUGUI>();
        textoCompleto = textoTMP.text;
        textoTMP.text = ""; // Lo deja vacío al inicio
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(EscribirTexto());
    }

    private IEnumerator EscribirTexto()
    {
        textoTMP.text = "";
        foreach (char letra in textoCompleto)
        {
            textoTMP.text += letra;
            yield return new WaitForSeconds(velocidad);
        }
    }
}