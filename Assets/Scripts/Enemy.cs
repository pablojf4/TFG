using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    public float velocidad = 5f;
    public int vida;
    private Rigidbody2D rb;

    [Header("Disparo")]
    public GameObject balaEnemiga;
    public float tiempoEntreDisparos = 2f;
    private float contadorDisparo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        contadorDisparo = tiempoEntreDisparos; // Primer disparo tras esperar el tiempo
    }

    void FixedUpdate()
    {
        // Movimiento hacia abajo constante
        rb.linearVelocity = new Vector2(0, -velocidad);

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Temporizador de disparo
        contadorDisparo -= Time.deltaTime;
        if (contadorDisparo <= 0f)
        {
            Disparar();
            contadorDisparo = tiempoEntreDisparos;
        }
    }

    void Disparar()
    {
        if (balaEnemiga != null)
        {
            Instantiate(balaEnemiga, transform.position, Quaternion.Euler(0, 0, 270));
        }
    }
}
