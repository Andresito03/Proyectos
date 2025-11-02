using TMPro;
using UnityEngine;

public class NumeroCartas : MonoBehaviour
{

    public TextMeshProUGUI textoCartas;
    public CartasHUD mazo;

    // SINCRONIZA EL NUEMERO DE CARTAS CON EL NUMERO QUE APARECE EN PANTALLA
    void Update()
    {
        if (mazo.mazo >= 0)
        {
            textoCartas.text = mazo.mazo.ToString();

        }
        else
        {
            textoCartas.text = "0";
        }
    }
}
