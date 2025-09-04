using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI dialogueText;
    public Button nextButton;
    public Button acceptButton; // Botón que aparecerá al final

    [Header("Dialogues")]
    private string[] dialogueLines = new string[]
    {
        "¡Hola, viajero! Bienvenido al río Aguacatal, el corazón de nuestra comunidad",

        "Pero estamos en peligro… la basura, la contaminación y el abandono nos están enfermando",

        "El Aguacatal ya no es el mismo, y nuestra gente también sufre sus heridas",

        "Necesitamos tu ayuda, cada misión será un paso para devolverle la vida al río",

        "¿Aceptarás luchar junto a nosotros por el Aguacatal?",
    };

    private int currentLine = 0;
    private Coroutine typingCoroutine;

    void Start()
    {
        nextButton.onClick.AddListener(NextLine);
        acceptButton.onClick.AddListener(LoadContextScene);

        // Ocultar el botón Aceptar al inicio
        acceptButton.gameObject.SetActive(false);

        ShowLine();
    }

    void ShowLine()
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
            yield return new WaitForSeconds(0.03f); // Velocidad de escritura
        }
    }

    void NextLine()
    {
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
            // Al terminar, ocultamos el botón NEXT y mostramos el de Aceptar
            nextButton.gameObject.SetActive(false);
            acceptButton.gameObject.SetActive(true);
        }
    }

    void LoadContextScene()
    {
        SceneManager.LoadScene("Contexto");
    }
}
