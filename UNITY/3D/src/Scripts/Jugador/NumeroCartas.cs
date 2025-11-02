using TMPro;
using UnityEngine;

public class NumeroCartas : MonoBehaviour
{

    public TextMeshProUGUI textoCartas;
    public CartasHUD mazo;

    // Update is called once per frame
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
