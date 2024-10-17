using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private float countdown = 5f;

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            Destroy(gameObject);

            //Wave.readyToCountdown = true;
            //Wave.currentWaveIndex++;
            //if (Wave.currentWaveIndex > 1)
            // {
            //  Wave.currentWaveIndex = 0; 
            // }


           // Waves.enemiesLeft--;

        }
    }
}

