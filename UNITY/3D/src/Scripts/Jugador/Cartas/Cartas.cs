using UnityEngine;
using System.Collections;

public class CartasHUD : MonoBehaviour
{
    public GameObject[] cartasPrefabs;  // Prefabs de cartas
    public Transform contenedorMano;     // Contenedor de la carta actual
    public Transform contenedorMazo;     // Contenedor de la siguiente carta
    public int mazo = 4;
    public int maxCartas = 4;
    public float temp = 0f;
    public float cd = 5f;
    public ControlCartas controlCartas;
    public AudioClip clip;
    private AudioSource source;

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
    }
    void Update()
    {
        temp += Time.deltaTime;
        if (temp > cd)
        {
            mazo++;
            temp = 0f;
        }

        // Crear cartas si el mazo está vacío
        if (contenedorMazo.childCount <= 0 && mazo > 0)
        {
            if (contenedorMano.childCount <= 0)
            {
                CrearNuevaCarta(contenedorMano);
                mazo--;
            }
            else
            {
                CrearNuevaCarta(contenedorMazo);
                mazo--;
            }
        }

        // Click del mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Ejecutar la eliminación y movimiento de cartas en la corutina
            StartCoroutine(ProcesarCartas());
        }
    }

    // Corutina para mover y eliminar cartas al siguiente frame
    IEnumerator ProcesarCartas()
    {
        yield return null; // espera al siguiente frame para evitar errores de UI

        // 1. Eliminar carta de la mano
        Lanzar(contenedorMano);

        // 2. Mover carta del mazo a la mano
        MoverCarta(contenedorMazo, contenedorMano);
    }

    // Lanza la carta y la elimina
    void Lanzar(Transform contenedor)
    {
        if (contenedor.childCount > 0)
        {
            source.Play();
            GameObject carta = contenedor.GetChild(0).gameObject;

            // Llamamos al otro script, pasando carta.name
            if (controlCartas != null)
            {
                controlCartas.EjecutarEfecto(carta.name);
            }

            Destroy(carta);

        }
    }

    // Crea una nueva carta aleatoria en el contenedor
    void CrearNuevaCarta(Transform contenedor)
    {
        int i = Random.Range(0, cartasPrefabs.Length);
        GameObject nuevaCarta = Instantiate(cartasPrefabs[i], contenedor);
        nuevaCarta.transform.localPosition = Vector3.zero;
        nuevaCarta.transform.localScale = Vector3.one;
    }

    // Mueve el primer hijo del mazo al destino
    void MoverCarta(Transform origen, Transform destino)
    {
        if (origen.childCount > 0)
        {
            Transform carta = origen.GetChild(0);
            carta.SetParent(destino, false);
            carta.localPosition = Vector3.zero;
            carta.localScale = Vector3.one;
        }
    }
}
