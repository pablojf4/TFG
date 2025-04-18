using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float timeBetweenSpawns = 2;
    float timer;

    void Update()
    {
        if (timer <= 0)
        {
            Instantiate(enemy, new Vector3(Random.Range(-2, 2), transform.position.y, 0), Quaternion.Euler(0, 0, 0));
            timer = timeBetweenSpawns;
        }
        timer -= Time.deltaTime;
    }
}