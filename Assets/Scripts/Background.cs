using UnityEngine;

public class MovimientoFondo : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    public float backgroundHeight; // Altura del sprite en unidades de mundo

    void Update()
    {
        // Mueve el fondo hacia abajo
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // Si el fondo sale completamente de la pantalla, lo reposiciona arriba
        if (transform.position.y <= -backgroundHeight)
        {
            float resetPosition = backgroundHeight; // Lo coloca arriba del otro fondo
            transform.position = new Vector3(transform.position.x, resetPosition, transform.position.z);
        }
    }
}
