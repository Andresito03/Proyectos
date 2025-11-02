using UnityEngine;
using System.Collections;

public class Impulso : MonoBehaviour
{
    // ======== CONFIGURACIÓN DE DASH ========
    public float fuerzaImpulso = 15f;  // Intensidad del impulso hacia adelante
    public float tiempo = 0.2f;        // Duración total del impulso
    public float cooldown = 5f;        // Tiempo de espera antes de poder usarlo otra vez

    // ======== CONTROL DE ESTADO ========
    private float ultimoDash;          // Guarda el tiempo del último dash
    private bool canDash = true;       // Indica si el jugador puede usar el dash
    private bool dashing = false;      // Indica si el jugador está dashing actualmente

    // ======== REFERENCIAS ========
    private Rigidbody rb;              // Referencia al componente de física
    public ParticleSystem dashViento;  // Partículas que se reproducen al hacer dash
    private VidaYalmas hud;            // HUD del juego para actualizar información al matar enemigos

    // ======== SONIDO ========
    public AudioClip clip;
    private AudioSource source;

    void Start()
    {
        // Cacheamos el Rigidbody (acceso directo más rápido)
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false; // Nos aseguramos de que esté bajo control de la física

        // Buscamos el HUD del juego (GameController)
        GameObject gameControl = GameObject.FindGameObjectWithTag("GameController");

        // Añadimos un AudioSource al objeto actual para reproducir sonido del dash
        source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;

        if (gameControl != null)
            hud = gameControl.GetComponent<VidaYalmas>();
    }

    void Update()
    {
        // Comprueba si ya pasó el tiempo de enfriamiento
        if (Time.time >= ultimoDash + cooldown)
            canDash = true;

        // Detecta clic derecho del ratón para activar el dash
        if (Input.GetMouseButtonDown(1) && canDash)
        {
            // Desactiva el dash temporalmente (entra en cooldown)
            canDash = false;
            ultimoDash = Time.time;

            source.Play(); // Reproduce sonido del impulso
            StartCoroutine(Dash()); // Inicia la corrutina del dash
        }
    }

    IEnumerator Dash()
    {

        // Activa efectos visuales y marca el estado como "dashing"
        dashViento.Play();
        dashing = true;

        // Guarda la dirección actual del jugador (hacia adelante)
        Vector3 direccion = transform.forward;

        // Desactiva la gravedad para que el impulso sea limpio
        rb.useGravity = false;

        // Mantiene la fuerza durante 'tiempo' segundos
        float t = 0f;
        while (t < tiempo)
        {
            // Se multiplica por deltaTime y un factor alto (50f) para simular impulso fuerte
            rb.AddForce(direccion * fuerzaImpulso * 50f * Time.deltaTime, ForceMode.VelocityChange);
            t += Time.deltaTime;

            // Espera al siguiente frame antes de continuar (pausa controlada)
            yield return null;
        }

        // Reactiva la gravedad al terminar
        rb.useGravity = true;
        dashing = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Solo afecta a enemigos si está dashing
        if (dashing && collision.gameObject.CompareTag("Enemy"))
        {
            hud.actualizar(); // Aumenta almas
            Destroy(collision.gameObject); // Elimina al enemigo al impactar
        }
    }
}
