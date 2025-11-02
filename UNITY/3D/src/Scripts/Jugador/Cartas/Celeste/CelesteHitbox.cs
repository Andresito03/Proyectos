using UnityEngine;

public class CelesteHitbox : MonoBehaviour
{
    public float escala = 30f;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") ) {
            Enemy estado = other.GetComponent<Enemy>();
            if (!estado.Afectado)
            {
                estado.DetenerPor5Segundos();
            }
        }

    }
}
