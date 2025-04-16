using UnityEngine;

public class BalaEnemiga : MonoBehaviour
{
    public float Velocidad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -Velocidad * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("barraInferior"))
        {
            Destroy(gameObject);
        }
    }
}