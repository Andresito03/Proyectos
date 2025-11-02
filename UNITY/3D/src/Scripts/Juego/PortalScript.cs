using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public TextMeshProUGUI objetivo;
    public string textObjetivo;
    public string nombreEscenaDestino = "";
    public GameObject Final;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && objetivo.text == textObjetivo)
        {
            if (Final != null)
            {
                // Activa el panel final y espera 5 segundos
                Final.SetActive(true);
                StartCoroutine(CargarEscenaConRetraso(5f));
            }
            else
            {
                // Si no hay panel, cambia de escena inmediatamente
                SceneManager.LoadScene(nombreEscenaDestino);
            }
        }
    }

    private IEnumerator CargarEscenaConRetraso(float segundos)
    {
        // CORTINA 
        yield return new WaitForSeconds(segundos);
        SceneManager.LoadScene(nombreEscenaDestino);
    }
}

