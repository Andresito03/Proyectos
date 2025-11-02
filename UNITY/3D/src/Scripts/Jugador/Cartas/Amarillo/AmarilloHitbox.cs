using System;
using UnityEngine;

public class AmarilloHitbox : MonoBehaviour
{
    public float escala = 30f;
    public GameObject hitboxPrefab;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") ) {
            Enemy estado = other.GetComponent<Enemy>();

            // Si no fua afectado por la electricidad crea el area electrica
            if (!estado.Afectado)
            {
                estado.Afectado = true;
                GameObject newHitbox = Instantiate(hitboxPrefab);
                newHitbox.transform.SetParent(other.transform);
                newHitbox.transform.localPosition = Vector3.zero;
                newHitbox.transform.localScale = new Vector3(escala, escala, escala);
                estado.muelto();
            }
        }

    }
}
