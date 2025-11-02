using UnityEngine;

public class MargenDialogo : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject panelDialogo;      // Panel de los diálogos
    public GameObject canvasInteractuar; // Canvas con el texto "Pulsa E para hablar"

    private bool jugadorEnRango = false;
    private bool dialogoActivo = false;

    void Start()
    {
        if (canvasInteractuar != null)
            canvasInteractuar.SetActive(false);

        if (panelDialogo != null)
            panelDialogo.SetActive(false);
    }

    void Update()
    {
        if (jugadorEnRango && Input.GetKeyDown(KeyCode.E))
        {
            // Activar el panel del diálogo
            if (panelDialogo != null)
                panelDialogo.SetActive(true);

            // Ocultar el texto de "Pulsa E para hablar"
            if (canvasInteractuar != null)
                canvasInteractuar.SetActive(false);

            dialogoActivo = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnRango = true;

            // Solo mostrar el texto si el diálogo no está activo
            if (canvasInteractuar != null && !dialogoActivo)
                canvasInteractuar.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnRango = false;

            // Ocultar texto e interfaz al salir del rango
            if (canvasInteractuar != null)
                canvasInteractuar.SetActive(false);

            if (panelDialogo != null)
                panelDialogo.SetActive(false);

            // Resetear estado para que vuelva a mostrarse al reentrar
            dialogoActivo = false;
        }
    }
}
