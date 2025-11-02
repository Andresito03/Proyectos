using UnityEngine;

public class RojoHitbox : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy estado = other.GetComponent<Enemy>();
            estado.rojo();

        }
    }
}
