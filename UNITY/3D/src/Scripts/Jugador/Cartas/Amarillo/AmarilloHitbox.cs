using System;
using UnityEngine;

public class AmarilloHitbox : MonoBehaviour
{
    public float escala = 30f;
    public GameObject hitboxPrefab;
    void OnTriggerEnter(Collider other)
    {
        // Supongamos que 'enemy' es el GameObject del enemigo
        // y 'hitboxPrefab' es el prefab que quieres crear como hijo
        if (other.CompareTag("Enemy") ) {
            Debug.Log("Colicion con enemigo amarilla");
            Enemy estado = other.GetComponent<Enemy>();
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
