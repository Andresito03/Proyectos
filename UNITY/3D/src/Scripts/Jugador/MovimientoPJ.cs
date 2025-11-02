using UnityEngine;

public class MovimientoRigidbody : MonoBehaviour
{

    public float velocidad = 6f;
    public float fuerzaSalto = 5f;
    public int vida = 100;
    public Transform referenciaSuelo;
    public LayerMask mascaraSuelo;
    private Rigidbody rb;
    private Vector3 direccionMovimiento;
    public ParticleSystem particulasDaño;
    public AudioClip clip;
    private AudioSource source;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;

    }

    void Update()
    {
        // Obtener input de movimiento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direccionMovimiento = transform.right * x + transform.forward * z;

        if (vida <= 0)
        {
            Camera cam = GetComponentInChildren<Camera>();
            if (cam != null)
            {
                cam.transform.SetParent(null); // la libera del jugador
                cam.transform.position = new Vector3(0, 10, 0); // posición temporal
                cam.transform.rotation = Quaternion.Euler(45, 0, 0);
            }

            Destroy(gameObject);
        }


        // Salto
        if (Input.GetButtonDown("Jump") && EstaEnElPiso())
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {

        Vector3 velocidadHorizontal = direccionMovimiento * velocidad;
        Vector3 nuevoVec = new Vector3(velocidadHorizontal.x, rb.linearVelocity.y, velocidadHorizontal.z);
        rb.linearVelocity = nuevoVec;
    }

    bool EstaEnElPiso()
    {
        return Physics.CheckSphere(referenciaSuelo.position, 0.4f, mascaraSuelo);
    }

    public void daño(int daño)
    {
        particulasDaño.Play();
        source.Play();
        vida -= daño;
    }

    public void curacion()
    {
        if (vida < 120)vida += 20;
    }

}
