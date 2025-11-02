using UnityEngine;

public class MoverRecto : MonoBehaviour
{
    public float velocidad = 30f;
    public float tiempoVida = 10f; // por si nunca colisiona
    private Vector3 direccion;

    void Start()
    {
        direccion = transform.forward;
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        transform.position += direccion * velocidad * Time.deltaTime;
    }
}
