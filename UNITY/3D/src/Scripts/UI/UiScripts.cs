using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{
    // CODIGOS LLAMDOS POR BOTONES 
    public GameObject panel;
    public GameObject panelJugar;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void JugarPanel()
    {
        if (!panelJugar.activeSelf)
        {
            panelJugar.SetActive(true);
        }

    }
    public void iniciarJuego()
    {

        SceneManager.LoadScene("Intro");

    }

    public void saltarIntro()
    {
        SceneManager.LoadScene("Partida");
    }

    public void salir()
    {

        Application.Quit();

    }

    public void configuraciones()
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
