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
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        transform.position += Time.deltaTime * movementSpeed * movement;

        if (Input.GetKey("space") && timer <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 90));
            audioManager.PlaySFX(audioManager.shot);
            timer = timeBetweenShots;
        }
        timer -= Time.deltaTime;

        score.text = points.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy Bullet"))
        {
            life -= 1;
        }
    }
}