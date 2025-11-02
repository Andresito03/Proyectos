using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject panelPausa;
    public bool juegoPausado = false;
    public GameObject Player;
    public GameObject Muelto;
    public GameObject Dialogos;

    void Start()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    
    }

    void Update()
    {
        // Pulsar ESC para pausar o reanudar
        if (Input.GetKeyDown(KeyCode.Escape) && !Dialogos.activeSelf)
        {
            if (juegoPausado)
                Reanudar();
            else
                Pausar();
        }

        if (Player == null)
        {
            Muelto.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            juegoPausado = true;
        }
    }

    public void Pausar()
    {
        panelPausa.SetActive(true);   // Mostrar panel
        Time.timeScale = 0f;          // Detener tiempo del juego
        juegoPausado = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Reanudar()
    {
        panelPausa.SetActive(false);  // Ocultar panel
        Time.timeScale = 1f;          // Reanudar tiempo
        juegoPausado = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;          // Asegurarse de reanudar el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
