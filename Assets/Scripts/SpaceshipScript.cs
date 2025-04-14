using Unity.VisualScripting;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody2D rb;
    public int vida;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Aplicar velocidad hacia abajo (en 2D, el eje Y negativo es hacia abajo)
        rb.linearVelocity = new Vector2(0, -velocidad);

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}