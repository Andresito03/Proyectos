using UnityEngine;
using TMPro;
using System.Collections;

// Este script controla el sistema de diálogos del juego,
// haciendo que el texto aparezca letra por letra en pantalla.
// CODIGO DEL CHAT
public class LineaDialogo
{
    public string personaje; // Nombre del personaje que habla
    [TextArea(2, 5)]
    public string texto;     // Texto del diálogo que dice
}

public class Dialogos : MonoBehaviour
{
    // 🔹 Referencias a los elementos del Canvas (UI)
    public TextMeshProUGUI cuadroDialogo;   // Donde aparece el texto del diálogo
    public TextMeshProUGUI nombrePersonaje; // Donde aparece el nombre del personaje
    public GameObject Panel;                // Panel que contiene todo el diálogo

    // 🔹 Array con todas las líneas de diálogo que se mostrarán
    public LineaDialogo[] dialogos;

    // 🔹 Velocidad con la que aparecen las letras (tiempo entre cada letra)
    public float velocidad = 0.02f;

    // 🔹 Índice del diálogo actual
    private int index;

    // 🔹 Referencia a un texto externo para mostrar un objetivo o instrucción
    public TextMeshProUGUI objetivo;

    // 🔹 Al iniciar el juego o escena, comienza el diálogo
    void Start()
    {
        StartDialogo();
    }

    // 🔹 Detecta clics del jugador para avanzar el diálogo
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            // Si ya se mostró toda la línea actual
            if (cuadroDialogo.text == dialogos[index].texto)
            {
                // Pasa a la siguiente línea
                SiguienteLinea();
            }
            else
            {
                // Si el texto aún se está escribiendo, lo muestra completo instantáneamente
                StopAllCoroutines();
                cuadroDialogo.text = dialogos[index].texto;
            }
        }
    }

    // 🔹 Inicia el primer diálogo
    public void StartDialogo()
    {
        index = 0; // Comienza desde la primera línea
        Panel.SetActive(true); // Muestra el panel de diálogo
        cuadroDialogo.text = string.Empty; // Limpia el texto del cuadro
        nombrePersonaje.text = dialogos[index].personaje; // Muestra el nombre del primer personaje
        StartCoroutine(LineaDialogo()); // Comienza a escribir el texto letra por letra
    }

    // 🔹 Corrutina que escribe el texto letra por letra
    IEnumerator LineaDialogo()
    {
        foreach (char letra in dialogos[index].texto.ToCharArray())
        {
            cuadroDialogo.text += letra; // Añade una letra al texto
            yield return new WaitForSeconds(velocidad); // Espera un poco antes de la siguiente letra
        }
    }

    // 🔹 Cambia a la siguiente línea de diálogo o termina la conversación
    public void SiguienteLinea()
    {
        if (index < dialogos.Length - 1) // Si aún quedan líneas
        {
            index++; // Avanza al siguiente diálogo
            cuadroDialogo.text = string.Empty; // Limpia el texto anterior
            nombrePersonaje.text = dialogos[index].personaje; // Cambia el nombre del personaje
            StartCoroutine(LineaDialogo()); // Comienza a escribir el nuevo texto
        }
        else
        {
            // Si ya no quedan líneas, cierra el panel y actualiza el objetivo
            Panel.SetAc

