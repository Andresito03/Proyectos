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
        // Evita que haya más de un MusicManager al cambiar de escena
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Recupera el estado del mute desde la última sesión
            isMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;

            // Carga la música de la escena actual sin romper el mute
            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);

            // Si el usuario había dejado el juego muteado, pausa la reproducción inicial
            if (isMuted && audioSource.isPlaying)
                audioSource.Pause();
        }
        else
        {
            // Si ya existe un MusicManager, destruye el duplicado
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Evita errores al descargar escenas
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip newClip = null;

        // Asigna la música según la escena actual
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
        // No cambia nada si no hay clip o si ya está sonando el mismo
        if (audioSource == null || newClip == null) return;
        if (audioSource.clip == newClip) return;

        audioSource.clip = newClip;

        // Si no está muteado, empieza la nueva canción normalmente
        if (!isMuted)
        {
            audioSource.Play();
        }
        else
        {
            // Si está muteado, prepara la canción en pausa
            // (permite que al desmutear se reanude instantáneamente)
            audioSource.Play();
            audioSource.Pause();
        }
    }

    public void ToggleMusic(bool isOn)
    {
        // El toggle envía true = encendido → por eso invertimos para mute
        isMuted = !isOn;

        if (audioSource == null) return;

        if (isMuted)
        {
            // Mute: pausa el audio (sin reiniciarlo)
            audioSource.Pause();
        }
        else
        {
            // Si estaba en pausa, simplemente continúa; si no, arranca
            if (!audioSource.isPlaying)
                audioSource.Play();
            else
                audioSource.UnPause();
        }

        // Guarda el estado para mantener la preferencia entre ejecuciones
        PlayerPrefs.SetInt("MusicMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    // Devuelve el estado actual de la música (para inicializar el toggle)
    public bool IsMusicOn()
    {
        return !isMuted;
    }
}
