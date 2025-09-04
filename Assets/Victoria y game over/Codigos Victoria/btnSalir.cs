using UnityEngine;

public class btnSalir : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void salirJuego()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }
}
