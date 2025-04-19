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
        //Obtiene la posicion actual de la bala
        Vector2 pos = transform.position;

        //Encuentra los limites de la pantalla para el movimiento de la bala enemiga
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));// Este es el punto (esquina) inferior izquierda de la pantalla.
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//Este es el punto (esquina) superior derecha de la pantalla.

        //Se revisa si la posicion de la bala enemiga en el eje y es menor al margen inferior de la camara
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