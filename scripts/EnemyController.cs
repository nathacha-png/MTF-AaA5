using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    // Referencia al Transform del jugador (asígnale el GameObject del jugador en el Inspector)
    public Transform player;
    
    // Velocidad de movimiento del enemigo
    public float speed = 2f;
    
    // Rango máximo para empezar a seguir (distancia en unidades)
    public float followRange = 5f;

    void Update()
    {
        // Calcula la distancia entre el enemigo y el jugador
        float distance = Vector2.Distance(transform.position, player.position);
        
        // Si está dentro del rango, sigue al jugador
        if (distance <= followRange)
        {
            // Calcula la dirección hacia el jugador
            Vector2 direction = (player.position - transform.position).normalized;
            
            // Mueve al enemigo en esa dirección
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
