using UnityEngine;
using UnityEngine.UI;

public class ToggleBoton : MonoBehaviour
{
    private Toggle toggle;                // Referencia al componente Toggle
    private MusicManager musicManager;    // Referencia al MusicManager

    private void Start()
    {
        toggle = GetComponent<Toggle>();

        // Buscar el MusicManager por tag
        GameObject musicObj = GameObject.FindGameObjectWithTag("MusicManager");
        if (musicObj != null)
        {
            musicManager = musicObj.GetComponent<MusicManager>();
        }

        if (musicManager != null)
        {
            // Sincroniza el estado inicial del Toggle con el MusicManager
            toggle.isOn = musicManager.IsMusicOn();

            // Conecta el evento del Toggle al método ToggleMusic del MusicManager
            toggle.onValueChanged.AddListener(musicManager.ToggleMusic);
        }
        else
        {
            Debug.LogWarning(" No se encontró el objeto con tag 'MusicManager'.");
        }
    }

    private void OnDestroy()
    {
        // Quita el listener cuando el objeto se destruya para evitar errores
        if (toggle != null)
            toggle.onValueChanged.RemoveAllListeners();
    }
}
