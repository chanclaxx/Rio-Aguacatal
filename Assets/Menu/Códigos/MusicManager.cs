using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    private AudioSource audioSource;
    private static bool isMuted = false; // estado global

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // persiste entre escenas
        }
        else
        {
            Destroy(gameObject); // evita duplicados
            return;
        }

        audioSource = GetComponent<AudioSource>();
        AplicarMute();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        AplicarMute();
    }

    private void AplicarMute()
    {
        if (audioSource != null)
            audioSource.mute = isMuted;
    }

    private void OnLevelWasLoaded(int level)
    {
        // Cuando cambias de escena, asegúrate de aplicar el mute
        audioSource = GetComponent<AudioSource>();
        AplicarMute();
    }
}