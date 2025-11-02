using UnityEngine;

public class Camara : MonoBehaviour
{
    public float sensivity = 100f;
    private float RotacionX = 0f;
    public Transform player;
    public float gravedad = -9.81f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    void Update()
    {
        if (player != null)
        {
            float MauseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
            float MauseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

            RotacionX -= MauseY;
            RotacionX = Mathf.Clamp(RotacionX, -90f, 90f);

            transform.localRotation = Quaternion.Euler(RotacionX, 0f, 0f);
            player.Rotate(Vector3.up * MauseX);
        }
    }
}
