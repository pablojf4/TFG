using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    private Vector3 movimiento;
    public GameObject bala;
    public float Timer, TiempoDeEspera;
    public LayerMask capaObstaculos; // ? Asegúrate de asignar esto en el Inspector
    public float distanciaColision = 0.1f;

    void Update()
    {
        // Movimiento
        movimiento = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;

        // Raycast para prevenir atravesar objetos
        if (!HayObstaculo(movimiento))
        {
            transform.position += movimiento * velocidad * Time.deltaTime;
        }

        // Disparo
        if (Input.GetKey("space") && Timer <= 0)
        {
            Instantiate(bala, transform.position, Quaternion.Euler(0, 0, 90));
            Timer = TiempoDeEspera;
        }
        Timer -= Time.deltaTime;
    }

    bool HayObstaculo(Vector3 direccion)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion, distanciaColision, capaObstaculos);
        return hit.collider != null;
    }
}
