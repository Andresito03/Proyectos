using UnityEngine;

//  Este script controla la rotación de la cámara con el movimiento del ratón (mouse)
// y sincroniza la rotación del jugador para crear un control en primera persona.
// CODIGO DEL CHAT
public class Camara : MonoBehaviour
{

    public float sensivity = 100f;
    private float RotacionX = 0f;
    public Transform player;
    public float gravedad = -9.81f;

    //  Al iniciar, bloquea el cursor en el centro de la pantalla
    //   para que el jugador no pueda sacarlo mientras juega
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    void Update()
    {
        // Solo se ejecuta si hay un jugador asignado
        if (player != null)
        {
            // Captura el movimiento del ratón en ambos ejes
            float MauseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
            float MauseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

            // Ajusta la rotación vertical (mirar arriba y abajo)
            RotacionX -= MauseY;

            // Limita la rotación vertical para evitar que la cámara gire más de 90°
            RotacionX = Mathf.Clamp(RotacionX, -90f, 90f);

            // Aplica la rotación vertical a la cámara (solo eje X)
            transform.localRotation = Quaternion.Euler(RotacionX, 0f, 0
