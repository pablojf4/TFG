using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    public int life;
    public GameObject enemyBullet;
    public float timeBetweenShots;

    AudioManager audioManager;
    Rigidbody2D rigidBody;
    float timer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        Destroy(gameObject, 10);
    }

    void Update()
    {
        rigidBody.linearVelocity = new Vector2(0, -movementSpeed);

        if (life <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<Player>().points += 1;
        }

        if (timer <= 0)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.Euler(0, 0, 270));
            audioManager.PlaySFX(audioManager.shot);
            timer = timeBetweenShots;
        }
        timer -= Time.deltaTime;
    }
}