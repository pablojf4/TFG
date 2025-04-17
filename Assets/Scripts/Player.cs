using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI score;
    public int points;
    public float movementSpeed;
    public int life;
    public GameObject bullet;
    public float timeBetweenShots;

    float timer;
    Vector3 movement;
    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        // basándonos en la entrada, calculamos un vector de dirección y lo normalizamos para obtener un vector unitario
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        //Llamamos a la función que calcula y establace la posición del jugador
        move (direction);
        
        if (Input.GetKey("space") && timer <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 90));
            audioManager.PlaySFX(audioManager.shot);
            timer = timeBetweenShots;
        }
        timer -= Time.deltaTime;

        score.text = points.ToString();
    }
    void move(Vector2 direction)
    {
        //Encuentra los límites de la pantalla para el movimiento del jugador
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));// Este es el punto (esquina) inferior izquierda de la pantalla.
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//Este es el punto (esquina) superior derecha de la pantalla.

        max.x = max.x - 0.18f;// Resta la mitad del ancho del sprite del jugador
        min.x = min.x + 0.18f;// Añade la mitad del ancho del sprite del jugador
        
        max.y = max.y - 0.395f;// Resta la mitad de la altura del sprite del jugador
        min.y = min.y + 0.395f;// Añade la mitad de la altura del sprite del jugador

        //Obtiene la posición actual del jugador
        Vector2 pos = transform.position;

        //Calcula la nueva posición
        pos += direction * movementSpeed * Time.deltaTime;

        //Nos aseguramos que la nueva posición no esté fuera de la pantalla
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //Actualiza la posición del jugador
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy Bullet"))
        {
            life -= 1;
        }
    }
}