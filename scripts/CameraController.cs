using UnityEngine;

public class CameraScreenFollow : MonoBehaviour
{
    public Transform personaje; // El Transform del personaje a seguir
    private Camera cam;
    private float screenHeight;
    private float screenWidth;

    void Start()
    {
        cam = Camera.main;
        UpdateScreenDimensions(); // Calcula el tamaño de la pantalla
    }

    void Update()
    {
        UpdateScreenDimensions(); // Actualiza si cambia el tamaño de la cámara
        CheckAndMoveCamera();
    }

    void UpdateScreenDimensions()
    {
        screenHeight = cam.orthographicSize * 2; // Altura total visible
        screenWidth = screenHeight * cam.aspect; // Ancho total visible
    }

    void CheckAndMoveCamera()
    {
        if (personaje == null) return;

        // Obtén la posición de la cámara actual
        Vector3 camPos = transform.position;

        // Calcula los límites de la pantalla actual
        float leftEdge = camPos.x - screenWidth / 2;
        float rightEdge = camPos.x + screenWidth / 2;
        float bottomEdge = camPos.y - screenHeight / 2;
        float topEdge = camPos.y + screenHeight / 2;

        // Verifica si el personaje salió de la pantalla
        Vector3 playerPos = personaje.position;
        bool moved = false;

        // Si sale por la derecha
        if (playerPos.x > rightEdge)
        {
            camPos.x += screenWidth;
            moved = true;
        }
        // Si sale por la izquierda
        else if (playerPos.x < leftEdge)
        {
            camPos.x -= screenWidth;
            moved = true;
        }

        // Si sale por arriba
        if (playerPos.y > topEdge)
        {
            camPos.y += screenHeight;
            moved = true;
        }
        // Si sale por abajo
        else if (playerPos.y < bottomEdge)
        {
            camPos.y -= screenHeight;
            moved = true;
        }

        // Aplica el movimiento si se detectó salida
        if (moved)
        {
            transform.position = camPos;
        }
    }
}
