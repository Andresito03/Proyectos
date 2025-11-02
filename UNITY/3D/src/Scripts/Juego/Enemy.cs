using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Vida inicial del enemigo
    int vida = 100;

    // Indicador de si el enemigo está afectado por alguna condición
    public bool Afectado = false;

    // Controla si el enemigo puede moverse
    public bool canMove = true;

    // Velocidad de movimiento del enemigo
    public float speed = 3f;

    // Indica si el enemigo está infectado y se comportará como aliado
    public bool Infectado = false;

    // Daño que inflige al jugador al colisionar
    public int dañoAlJugador = 20;

    // Referencia al jugador
    private GameObject targetPlayer;

    // Referencia a otro enemigo (usado cuando este enemigo está infectado)
    private GameObject targetEnemy;

    // Referencia al HUD que controla vida y otras UI
    private VidaYalmas hud;

    void Start()
    {
        // Buscar al jugador en la escena mediante su tag
        targetPlayer = GameObject.FindGameObjectWithTag("Player");

        // Buscar al GameController para obtener referencia al HUD
        GameObject gameControl = GameObject.FindGameObjectWithTag("GameController");

        if (gameControl != null)
            hud = gameControl.GetComponent<VidaYalmas>();
        else
            Debug.LogWarning("No se encontró un objeto con el tag 'GameController'.");
    }

    void Update()
    {
        // Si la vida llega a 0 o menos, actualizar HUD y destruir este enemigo
        if (vida <= 0)
        {
            if (hud != null)
                hud.actualizar();

            Destroy(gameObject);
            return;
        }
        // Si no puede moverse, salir del Update
        if (!canMove)
            return;



        GameObject objetivo = null;

        // Lógica de movimiento según si el enemigo está infectado o no
        if (Infectado)
        {
            // Cambiar tag para que ahora sea aliado
            gameObject.tag = "Ally";

            // Buscar otro enemigo como objetivo
            targetEnemy = GameObject.FindGameObjectWithTag("Enemy");
            objetivo = targetEnemy;
        }
        else
        {
            // Si no está infectado, el objetivo es el jugador
            objetivo = targetPlayer;
        }

        if (objetivo == null)
            return;

        // Calcular dirección hacia el objetivo y mover al enemigo
        Vector3 direction = (objetivo.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Girar el enemigo para mirar al objetivo
        transform.LookAt(objetivo.transform);
    }

    // Función que mata al enemigo d
    public void muelto()
    {
        if (hud != null)
            hud.actualizar();
        Destroy(gameObject, 1f); // Destruye el enemigo después de 1 segundo
    }

    // Función que reduce vida cuando recibe un golpe dela carta roja
    public void rojo()
    {
        vida -= 50;
    }

    //  Detener al enemigo por 5 segundos
    public void DetenerPor5Segundos()
    {
        if (canMove)
        {
            canMove = false; // Desactivar movimiento
            StartCoroutine(ReanudarMovimiento()); // Iniciar coroutine para reanudar
        }
    }

    // Coroutine que espera 5 segundos antes de permitir que el enemigo se mueva nuevamente
    private System.Collections.IEnumerator ReanudarMovimiento()
    {
        yield return new WaitForSeconds(5f);
        canMove = true; // Reactivar movimiento
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si colisiona con el jugador y puede moverse, inflige daño
        if (collision.gameObject.CompareTag("Player") && canMove)
        {
            MovimientoRigidbody jugador = collision.gameObject.GetComponent<MovimientoRigidbody>();
            if (jugador != null)
            {
                jugador.daño(dañoAlJugador);
            }
        }

        // Si colisiona con otro enemigo mientras está infectado, destruir ambos
        else if (collision.gameObject.CompareTag("Enemy") && Infectado)
        {
            hud.actualizar(); // Actualiza HUD
            hud.actualizar();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
