using UnityEngine;

public class Background : MonoBehaviour
{
    float velocidad = 1f; // Velocidad del movimiento
    float altura = 2.7f; // Altura de un fondo
    float limiteY = -2.7f; // Límite en el eje Y donde el fondo se reposiciona

    void Update()
    {
        // Mueve el fondo hacia abajo
        transform.position += Vector3.down * velocidad * Time.deltaTime;

        // Cuando el fondo llega al límite, se reposiciona en el fondo superior
        if (transform.position.y <= limiteY)
        {
            // Reposiciona el fondo a la parte superior
            transform.position =
                new Vector3(transform.position.x, transform.position.y + altura * 3, transform.position.z);
        }
    }
}