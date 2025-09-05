using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public GameObject panelDialogo;

    public void TogglePanel()
    {
        if (panelDialogo != null)
        {
            // Alterna entre activo e inactivo
            panelDialogo.SetActive(!panelDialogo.activeSelf);
        }
        else
        {
            Debug.LogWarning("No se ha asignado un panel en el inspector.");
        }
    }
}