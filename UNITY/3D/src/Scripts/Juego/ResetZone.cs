using UnityEngine;

public class ResetZone : MonoBehaviour
{
    // Destruye to lo que lo toca, si es el jugado le pone la vida a 0 pa que no se destruya la camara con el
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MovimientoRigidbody script = other.GetComponent<MovimientoRigidbody>();
            script.vida = 0;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
