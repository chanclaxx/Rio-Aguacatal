
using UnityEngine;

public class BtnMute : MonoBehaviour
{
    public void OnMuteButtonPressed()
    {
        MusicManager manager = FindObjectOfType<MusicManager>();
        if (manager != null)
        {
            manager.ToggleMute();
        }
        else
        {
            Debug.LogWarning("No se encontró el MusicManager en la escena.");
        }
    }
}