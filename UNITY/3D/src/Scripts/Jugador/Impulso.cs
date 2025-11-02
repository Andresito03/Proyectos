using UnityEngine;
using System.Collections;

public class Impulso : MonoBehaviour
{
    public float fuerzaImpulso = 15f;
    public float tiempo = 0.2f;
    public float cooldown = 5f;

    private float ultimoDash;
    private bool canDash = true;
    private bool dashing = false;
    private Rigidbody rb;

    public ParticleSystem dashViento;
    private VidaYalmas hud;
    public AudioClip clip;
    private AudioSource source;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;

        GameObject gameControl = GameObject.FindGameObjectWithTag("GameController");
        source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;

        if (gameControl != null)
            hud = gameControl.GetComponent<VidaYalmas>();
    }

    void Update()
    {
        // Revisa si ya pasó el cooldown
        if (Time.time >= ultimoDash + cooldown)
            canDash = true;

        if (Input.GetMouseButtonDown(1) && canDash)
        {
            // Bloquea el dash antes de empezarlo
            canDash = false;
            ultimoDash = Time.time;

            source.Play();
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        dashViento.Play();
        dashing = true;

        Vector3 direccion = transform.forward;
        rb.useGravity = false;

        float t = 0f;
        while (t < tiempo)
        {
            rb.AddForce(direccion * fuerzaImpulso * 50f * Time.deltaTime, ForceMode.VelocityChange);
            t += Time.deltaTime;
            yield return null;
        }

        rb.useGravity = true;
        dashing = false;
    }




    void OnCollisionEnter(Collision collision)
    {
        if (dashing && collision.gameObject.CompareTag("Enemy"))
        {
            hud.actualizar();
            Destroy(collision.gameObject);
        }
    }
}
