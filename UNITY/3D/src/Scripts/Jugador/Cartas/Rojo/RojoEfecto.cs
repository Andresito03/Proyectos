using UnityEngine;

public class RojoEfecto : MonoBehaviour
{
    public GameObject Explosion; // El efecto de explosión (hijo)
    private Rigidbody rb;
    private MoverRecto mover; // Si usas tu script alternativo de movimiento

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mover = GetComponent<MoverRecto>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Activar la explosión

        if (other.CompareTag("Player")) return;
        if (other.CompareTag("Carta")) return;

        if (Explosion != null)
            Explosion.SetActive(true);

        // Detener movimiento
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true; // Para que no siga afectado por físicas
        }

        if (mover != null)
        {
            mover.velocidad = 0f;
        }

        // Destruir el proyectil después de 1 segundo
        Destroy(gameObject, 1f);
    }
}
