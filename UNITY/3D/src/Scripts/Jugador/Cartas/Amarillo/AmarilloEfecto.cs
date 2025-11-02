using UnityEngine;

public class AmarilloEfecto : MonoBehaviour
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
        if (other.CompareTag("Carta")) return;
        if (other.CompareTag("Player")) return;
        
        // Activar Efectp
        
        if (other.CompareTag("Enemy"))
        {

            if (Explosion != null)
                Explosion.SetActive(true);

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.isKinematic = true; 
            }

            if (mover != null)
            {
                mover.velocidad = 0f;
            }
            Destroy(gameObject, 0.1f);

        }

    }
}
