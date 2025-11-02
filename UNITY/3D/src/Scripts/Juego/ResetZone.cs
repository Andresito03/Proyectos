using UnityEngine;

public class ResetZone : MonoBehaviour
{

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
