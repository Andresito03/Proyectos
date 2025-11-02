using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public Slider sliderVolumen;
    public AudioSource musicaFondo; 

    void Start()
    {
 
        sliderVolumen.value = musicaFondo.volume;

        sliderVolumen.onValueChanged.AddListener(CambiarVolumen);
    }

    void CambiarVolumen(float valor)
    {
        musicaFondo.volume = valor;
        Debug.Log("Volumen: " + valor);
    }
}
