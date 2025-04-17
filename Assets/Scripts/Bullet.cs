using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        //Obtiene la posición actual de la bala
        Vector2 pos = transform.position;

        //Encuentra los límites de la pantalla para el movimiento de la bala
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));// Este es el punto (esquina) inferior izquierda de la pantalla.
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//Este es el punto (esquina) superior derecha de la pantalla.

        //Se revisa si la posición de la bala en el eje y es superior al margen superior de la cámara
        //Si es superior se destruye la bala
        if (pos.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().life -= 1;
            Destroy(gameObject);
        }
    }
}