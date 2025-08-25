using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI dialogueText; // Asigna tu TMP Text aquí
    public Button nextButton;

    [Header("Dialogues")]
    private string[] dialogueLines = new string[]
    {
        "¡Hola, viajero! No todos los días alguien viene a visitarnos por el río Aguacatal…",
        "¿Sabías que este lugar es el corazón de nuestra comunidad? Pero algo anda mal… El agua ya no es tan clara como antes",
        "Mira a tu alrededor, ¿ves esas bolsas y botellas? Cada día llegan más, la basura se acumula y está enfermando al río… y también a nosotros",
        "La contaminación no solo afecta al ambiente, también a nuestra cultura… Por eso necesitamos tu ayuda",
        "Cada misión que realices en este juego será un pequeño paso para devolverle la vida al Aguacatal",
        "¿Aceptas unirte a nosotros y luchar por nuestro río?"
    };

    private int currentLine = 0;
    private Coroutine typingCoroutine;

    void Start()
    {
        nextButton.onClick.AddListener(NextLine);
        ShowLine();
    }

    void ShowLine()
    {
        // Detener escritura anterior si existe
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
            yield return new WaitForSeconds(0.03f); // Velocidad de escritura
        }
    }

    void NextLine()
    {
        // Si aún se está escribiendo, mostrar la línea completa
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
            gameObject.SetActive(false); // Oculta el panel al terminar
        }
    }
}