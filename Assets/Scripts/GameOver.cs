using UnityEngine;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        if (gameObject.GetComponent<Player>().life <= 0)
        {
           Time.timeScale = 0;
        }
    }
}