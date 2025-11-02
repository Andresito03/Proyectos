using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objetoAParir;  // Prefab a spawnear
    public float intervalo;      // Tiempo entre spawns

    private float contador = 0f;

    void Update()
    {

        contador += Time.deltaTime;

        if (contador >= intervalo)
        {
            if (objetoAParir != null)
            {
                Instantiate(objetoAParir, transform.position, Quaternion.identity);
            }
            contador = 0f;
        }
    }
}
