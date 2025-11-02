using UnityEngine;

public class Enemy : MonoBehaviour
{
    int vida = 100;
    public bool Afectado = false;
    public bool canMove = true;
    public float speed = 3f;
    public bool Infectado = false;
    public int dañoAlJugador = 20;
    private GameObject targetPlayer;
    private GameObject targetEnemy;
    private VidaYalmas hud; // referencia al HUD

    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");

        GameObject gameControl = GameObject.FindGameObjectWithTag("GameController");

        if (gameControl != null)
            hud = gameControl.GetComponent<VidaYalmas>();
        else
            Debug.LogWarning("No se encontró un objeto con el tag 'GameController'.");
    }

    void Update()
    {
        if (vida <= 0)
        {
            if (hud != null)
                hud.actualizar();

            Destroy(gameObject);
            return;
        }

        if (!canMove)
            return;

        GameObject objetivo = null;

        if (Infectado)
        {
            gameObject.tag = "Ally";
            targetEnemy = GameObject.FindGameObjectWithTag("Enemy");
            objetivo = targetEnemy;
        }
        else
        {
            objetivo = targetPlayer;
        }

        if (objetivo == null)
            return;

        Vector3 direction = (objetivo.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        transform.LookAt(objetivo.transform);
    }

    public void muelto()
    {
        if (hud != null)
            hud.actualizar();
        Destroy(gameObject, 1f);
    }

    public void rojo()
    {
        vida -= 50;
    }

    // 🔹 Llama a esta función cuando quieras que el enemigo se quede quieto
    public void DetenerPor5Segundos()
    {
        if (canMove)
        {
            canMove = false;
            StartCoroutine(ReanudarMovimiento());
        }
    }

    // 🔹 Corutina que espera 5 segundos antes de volver a activar el movimiento
    private System.Collections.IEnumerator ReanudarMovimiento()
    {
        yield return new WaitForSeconds(5f);
        canMove = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && canMove)
        {
            MovimientoRigidbody jugador = collision.gameObject.GetComponent<MovimientoRigidbody>();
            if (jugador != null)
            {
                jugador.daño(dañoAlJugador);
            }
        }
        else if (collision.gameObject.CompareTag("Enemy") && Infectado)
        {
            hud.actualizar();
            hud.actualizar();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
