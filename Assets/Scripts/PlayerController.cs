using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    private Vector3 movimiento;
    public GameObject bala;
    public float Timer, TiempoDeEspera;
    public LayerMask capaObstaculos;
    public float distanciaColision = 0.1f;
    
    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        movimiento = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;

        if (!HayObstaculo(movimiento))
        {
            transform.position += movimiento * velocidad * Time.deltaTime;
        }

        if (Input.GetKey("space") && Timer <= 0)
        {
            Instantiate(bala, transform.position, Quaternion.Euler(0, 0, 90));
            audioManager.PlaySFX(audioManager.shoot);
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
