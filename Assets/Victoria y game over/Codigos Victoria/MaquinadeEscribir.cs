using System.Collections;
using UnityEngine;
using TMPro;

public class MaquinadeEscribir : MonoBehaviour
{
     [Header("UI Elements")]
    public TextMeshProUGUI dialogueText; // Arrastra aquí tu TMP Text (el del cuadro de diálogo)

    [Header("Configuración")]
    [TextArea(3, 5)]
    public string[] dialogueLines; // Aquí escribes tus líneas de diálogo en el Inspector
    public float typingSpeed = 0.03f; // Velocidad de escritura

    private int currentLine = 0;
    private Coroutine typingCoroutine;

    void Start()
    {
        if (dialogueText != null && dialogueLines.Length > 0)
        {
            ShowLine();
        }
    }

    public void ShowLine()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeLine(dialogueLines[currentLine]));
    }

    IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextLine()
    {
        // Si aún se está escribiendo, terminar rápido
        if (dialogueText.text != dialogueLines[currentLine])
        {
            StopCoroutine(typingCoroutine);
            dialogueText.text = dialogueLines[currentLine];
            return;
        }

        currentLine++;
        if (currentLine < dialogueLines.Length)
        {
            ShowLine();
        }
        else
        {
            // Cuando termina todo
            Debug.Log("Fin del diálogo");
        }
    }
}