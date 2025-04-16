
using UnityEngine;

public class MuerteAlChocarConNave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si choca con un objeto etiquetado como "Nave" (enemiga)
        if (other.CompareTag("Nave")||other.CompareTag("balaEnemiga"))
        {
            // Detiene el juego (pausa todo)
            Time.timeScale = 0;

            // Opcional: Muestra un mensaje en consola
            Debug.Log("Has chocado con una nave enemiga! Juego pausado.");

            // (Opcional) Destruye ambos objetos
            // Destroy(gameObject); // Destruye la nave del jugador
            // Destroy(other.gameObject); // Destruye la nave enemiga
        }
    }
}