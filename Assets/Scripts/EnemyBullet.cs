using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        //Obtiene la posici�n actual de la bala
        Vector2 pos = transform.position;

        //Encuentra los l�mites de la pantalla para el movimiento de la bala enemiga
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));// Este es el punto (esquina) inferior izquierda de la pantalla.
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//Este es el punto (esquina) superior derecha de la pantalla.

        //Se revisa si la posici�n de la bala enemiga en el eje y es menor al margen inferior de la c�mara
        //Si es superior se destruye la bala enemiga
        if (pos.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}