using UnityEngine;

public class PotiCuracion : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // obtener el script del jugador
            MovimientoRigidbody jugador = other.GetComponent<MovimientoRigidbody>();

            if (jugador != null)
            {
                // Llama a la función del jugador
                jugador.curacion();
                Destroy(gameObject);
            }

        }
    }
}
