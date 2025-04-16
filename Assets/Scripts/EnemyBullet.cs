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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}