using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    private Vector3 movimiento;
    public GameObject bala;
    public float Timer, TiempoDeEspera;
    void Start()
    {
      
    }

    void Update()
    {

        // Asignamos directamente la velocidad al Rigidbody2D
        movimiento = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        movimiento = movimiento.normalized;
        transform.position += movimiento * velocidad* Time.deltaTime;
        if (Input.GetKey("space")&& Timer <=0)
        {
            Instantiate(bala, transform.position, Quaternion.Euler(0, 0, 90));
            Timer = TiempoDeEspera;
        }
        Timer -= Time.deltaTime;
    }

}