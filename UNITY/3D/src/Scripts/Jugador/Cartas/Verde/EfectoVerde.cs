using UnityEngine;

public class EfectoVerde : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) return;

        // Activar EfecticoooOoOoOo

        if (other.CompareTag("Enemy"))
        {
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

            Enemy estado = other.GetComponent<Enemy>();
            if (!estado.Afectado)
            {
                estado.Infectado = true;

            }
            Destroy(gameObject);

        }

    }
}