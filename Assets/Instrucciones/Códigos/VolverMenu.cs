using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverMenu : MonoBehaviour
{
    public string nombreMenu = "Menu";

    
    public void RegresarAlMenu()
    {
        SceneManager.LoadScene(nombreMenu);
    }
}