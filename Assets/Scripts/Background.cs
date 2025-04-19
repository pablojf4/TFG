using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed = 1f;
    float height = 9.5f;

    void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

        // Cuando el fondo llega al límite, se reposiciona en el fondo superior
        if (transform.position.y <= -height)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + height * 3, transform.position.z);
        }
    }
}