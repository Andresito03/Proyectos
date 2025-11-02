using UnityEngine;
using TMPro;
using System.Collections;

[System.Serializable]
public class LineaDialogo
{
    public string personaje; // Nombre del que habla
    [TextArea(2, 5)]
    public string texto;     // Texto que dice
}

public class Dialogos : MonoBehaviour
{
    public TextMeshProUGUI cuadroDialogo;
    public TextMeshProUGUI nombrePersonaje;
    public GameObject Panel;

    public LineaDialogo[] dialogos;
    public float velocidad = 0.02f;

    private int index;
    public TextMeshProUGUI objetivo;

    void Start()
    {
        StartDialogo();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cuadroDialogo.text == dialogos[index].texto)
            {
                SiguienteLinea();
            }
            else
            {
                StopAllCoroutines();
                cuadroDialogo.text = dialogos[index].texto;
            }
        }
    }

    public void StartDialogo()
    {
        index = 0;
        Panel.SetActive(true);
        cuadroDialogo.text = string.Empty;
        nombrePersonaje.text = dialogos[index].personaje;
        StartCoroutine(LineaDialogo());
    }

    IEnumerator LineaDialogo()
    {
        foreach (char letra in dialogos[index].texto.ToCharArray())
        {
            cuadroDialogo.text += letra;
            yield return new WaitForSeconds(velocidad);
        }
    }

    public void SiguienteLinea()
    {
        if (index < dialogos.Length - 1)
        {
            index++;
            cuadroDialogo.text = string.Empty;
            nombrePersonaje.text = dialogos[index].personaje;
            StartCoroutine(LineaDialogo());
        }
        else
        {
            Panel.SetActive(false);
            objetivo.text = "Vuelve al portal";
        }
    }
}
