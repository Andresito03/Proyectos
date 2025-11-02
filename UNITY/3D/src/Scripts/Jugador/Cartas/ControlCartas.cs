using UnityEngine;

public class ControlCartas : MonoBehaviour
{

    public GameObject[] efectosCartas; // Prefabs de proyectiles o efectos

    public Camera camaraJugador;        // Cámara del jugador
    public Transform puntoLanzamiento;  // Desde dónde se lanza el proyectil

 
    public float velocidadLanzamiento = 30f;

    public void EjecutarEfecto(string nombreCarta)
    {
        nombreCarta = nombreCarta.Replace("(Clone)", "").Trim();

        Debug.Log("Ejecutando efecto de la carta: " + nombreCarta);

        switch (nombreCarta)
        {
            case "Rojo":
                LanzarEfecto(0);
                break;

            case "Amarillo":
                LanzarEfecto(1);
                break;

            case "Celeste":
                LanzarEfecto(2);
                break;
                
            case "Verde":
                LanzarEfecto(3);
                break;

            default:
                Debug.LogWarning("Carta sin efecto definido: " + nombreCarta);
                break;
        }
    }

    void LanzarEfecto(int index)
    {
        if (efectosCartas == null || index < 0 || index >= efectosCartas.Length)
        {
            Debug.LogWarning("⚠ Índice de efecto inválido o prefab no asignado.");
            return;
        }

        if (camaraJugador == null || puntoLanzamiento == null)
        {
            Debug.LogWarning("⚠ Faltan referencias a la cámara o al punto de lanzamiento.");
            return;
        }

        // Crear el proyectil en el punto de lanzamiento
        GameObject proyectil = Instantiate(
            efectosCartas[index],
            puntoLanzamiento.position,
            Quaternion.identity
        );

        // Hacer que mire hacia donde apunta la cámara
        Vector3 direccion = camaraJugador.transform.forward;
        proyectil.transform.forward = direccion;

        // Mover recto (sin gravedad)
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.linearVelocity = direccion * velocidadLanzamiento;
        }
        else
        {
            // Si no tiene Rigidbody, agregarle movimiento lineal
            proyectil.AddComponent<MoverRecto>().velocidad = velocidadLanzamiento;
        }
    }
}

