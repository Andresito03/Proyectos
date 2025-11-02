using TMPro;
using UnityEngine;

public class VidaYalmas : MonoBehaviour
{
    public TextMeshProUGUI vida;
    public TextMeshProUGUI almas;
    public GameObject player;
    public int almasInt = 0;
    public GameObject portal;
    public int almasObjetivo;

    private MovimientoRigidbody playerScript; // referencia al script del jugador

    void Start()
    {

        playerScript = player.GetComponent<MovimientoRigidbody>();
    }
    void Update()
    {
        // actualiza el panel con la informacion del script del jugador que conseguimos en el start
        vida.text = "HP: " + playerScript.vida + "/100";
        if (almasInt >= almasObjetivo)
        {
            portal.SetActive(true);
            almas.text = "Vuelve al portal";
        } else
        {
            almas.text = almasInt + "/"+ almasObjetivo;
        }
        
    }

    public void actualizar()
    {
        almasInt++; // Funcion que llaman otros codigos para actualizar la info
    }
}
