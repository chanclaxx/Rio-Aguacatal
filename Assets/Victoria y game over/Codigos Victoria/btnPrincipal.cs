using UnityEngine;
using UnityEngine.SceneManagement;

public class btnPrincipal : MonoBehaviour
{
    public string menu;

    public void IrAEscena()
    {
        SceneManager.LoadScene(1);
    }
}
