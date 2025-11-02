using UnityEngine;

public class MovimientoRigidbody : MonoBehaviour
{
    public float velocidad = 6f;
    public float fuerzaSalto = 5f;
    public int vida = 100;

    public Transform referenciaSuelo;    // Punto desde donde se verifica si el jugador está tocando el suelo
    public LayerMask mascaraSuelo;       // Qué capas cuentan como "suelo"

    private Rigidbody rb;
    private Vector3 direccionMovimiento;

    public ParticleSystem particulasDaño;
    public AudioClip clip;
    private AudioSource source;

    void Start()
    {
        // Cacheo de componentes: evita buscar en cada frame
        rb = GetComponent<Rigidbody>();
        source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
    }

    void Update()
    {
        // Calcula la dirección del movimiento según input del jugador
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direccionMovimiento = transform.right * x + transform.forward * z;

        // Si el jugador muere, libera la cámara para que no se destruya con el personaje
        if (vida <= 0)
        {
            Camera cam = GetComponentInChildren<Camera>();
            if (cam != null)
            {
                // Se desacopla la cámara antes de destruir al jugador
                cam.transform.SetParent(null);
                cam.transform.position = new Vector3(0, 10, 0);
            }

            Destroy(gameObject);
        }

        // Salto solo permitido si está en el suelo
        if (Input.GetButtonDown("Jump") && EstaEnElPiso())
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Ejecuta el movimiendo del update, se ejecuta en un FixedUpdate para evitar variaciones entre dispositivos
        Vector3 velocidadHorizontal = direccionMovimiento * velocidad;

        Vector3 nuevoVec = new Vector3(velocidadHorizontal.x, rb.linearVelocity.y, velocidadHorizontal.z);
        rb.linearVelocity = nuevoVec;
    }

    bool EstaEnElPiso()
    {
        // Detección simple de suelo con un pequeño radio bajo el jugador
        return Physics.CheckSphere(referenciaSuelo.position, 0.4f, mascaraSuelo);
    }

    public void daño(int daño)
    {
        // Efectos visuales y sonoros al recibir daño
        particulasDaño.Play();
        source.Play();
        vida -= daño;
    }

    public void curacion()
    {
        // Cura una cantidad fija sin superar el máximo permitido
        if (vida < 120)
            vida += 20;
    }
}
