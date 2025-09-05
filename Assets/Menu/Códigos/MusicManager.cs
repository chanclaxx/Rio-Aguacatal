using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    // Estado global de mute
    private static bool isMuted = false;

    // Escenas donde debe sonar la música (ajusta según tus nombres de escena)
    [SerializeField] private string[] escenasConMusicaMenu = { "Menu", "Creditos" };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();

        // Suscribirse al cambio de escena
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Configuración inicial
        AplicarMuteATodos();
        ControlarMusica(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Revisa si en la nueva escena debe sonar la música
        ControlarMusica(scene.name);

        // Aplica mute global
        AplicarMuteATodos();
    }

    private void ControlarMusica(string escenaActual)
    {
        if (audioSource == null) return;

        // Reproduce solo si la escena está en la lista
        bool debeSonar = false;
        foreach (string escena in escenasConMusicaMenu)
        {
            if (escena == escenaActual)
            {
                debeSonar = true;
                break;
            }
        }

        if (debeSonar)
        {
            if (!audioSource.isPlaying) audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        AplicarMuteATodos();
    }

    private void AplicarMuteATodos()
    {
        AudioSource[] allSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in allSources)
        {
            source.mute = isMuted;
        }
    }
}
