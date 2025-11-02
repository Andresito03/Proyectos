using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    private AudioSource audioSource;

    public AudioClip menuMusic;
    public AudioClip partida;

    private bool isMuted;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Leer estado guardado antes de hacer nada
            isMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;

            // Iniciar la música de la escena actual (sin sonar si está muteado)
            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);

            // Si está muteado al iniciar, asegúrate de que esté en pausa
            if (isMuted && audioSource.isPlaying)
                audioSource.Pause();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip newClip = null;

        switch (scene.name)
        {
            case "Menu":
            case "Intro":
            case "Fin":
                newClip = menuMusic;
                break;

            case "Partida":
                newClip = partida;
                break;
        }

        ChangeMusic(newClip);
    }

    public void ChangeMusic(AudioClip newClip)
    {
        if (audioSource == null || newClip == null) return;

        if (audioSource.clip != newClip)
        {
            audioSource.clip = newClip;

            // Solo reproducir si NO está muteado
            if (!isMuted)
            {
                audioSource.Play();
            }
            else
            {
                // Precargar el clip en pausa (sin sonido)
                audioSource.Play();
                audioSource.Pause();
            }
        }
    }

    // 🔹 Llamada desde el Toggle
    public void ToggleMusic(bool isOn)
    {
        isMuted = !isOn;

        if (audioSource == null) return;

        if (isMuted)
        {
            audioSource.Pause();
        }
        else
        {
            // Si la música no está sonando (porque se inició muteada), arrancamos
            if (!audioSource.isPlaying)
                audioSource.Play();
            else
                audioSource.UnPause();
        }

        PlayerPrefs.SetInt("MusicMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();

        Debug.Log("🎵 Música " + (isMuted ? "pausada" : "reanudada"));
    }

    public bool IsMusicOn()
    {
        return !isMuted;
    }
}
