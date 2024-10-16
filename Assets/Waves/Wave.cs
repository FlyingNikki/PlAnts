using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

/*public class Wave : MonoBehaviour
{

    private IEnumerator Spawnwave()
    {

        for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
        {
            if (randomSpawn == 1)
            {

                Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint1.transform);

                enemy.transform.SetParent(spawnPoint1.transform);
                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
            if (randomSpawn == 2)
            {
                Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint2.transform);

                enemy.transform.SetParent(spawnPoint1.transform);
                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
            if (randomSpawn == 3)
            {
                Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint3.transform);

                enemy.transform.SetParent(spawnPoint1.transform);
                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
            if (randomSpawn == 4)
            {
                Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint4.transform);

                enemy.transform.SetParent(spawnPoint1.transform);
                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }

        }
    }
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
    [SerializeField] private GameObject spawnPoint3;
    [SerializeField] private GameObject spawnPoint4;
    [SerializeField] private float countdown;

    public static bool readyToCountdown;
    public static int currentWaveIndex = 0;
    public Waves[] waves;
    public int randomSpawn;

    public spawnPunkt[] spawnPoints;




    // Start is called before the first frame update
    void Start()
    {
        readyToCountdown = true;
        for (int i = 0; i < waves.Length; i++)
        {
            Waves.enemiesLeft = waves[i].enemies.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToCountdown == true)
        {
            countdown -= Time.deltaTime;
        }


        if (countdown < 0)
        {

            //countdown = waves[currentWaveIndex].timeToNextWave;
            StartCoroutine(Spawnwave());
            countdown = waves[currentWaveIndex].timeToNextWave;
            readyToCountdown = false;

        }
        if (currentWaveIndex > 1)
        {
            currentWaveIndex = 0;
        }

        if (Waves.enemiesLeft == 0)
        {
            readyToCountdown = true;
            currentWaveIndex++;
        }
        if (countdown == 0)
        {
            randomSpawn = Random.Range(1, 5);
        }
        if (randomSpawn == 0)
        {
            randomSpawn = Random.Range(1, 5);
        }
        // Waves.enemiesLeft = waves[currentWaveIndex].enemies.Length; 

    }


}

[System.Serializable]
public class Waves
{
    public Enemy[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;
    /*[HideInInspector]*/
/*    public static int enemiesLeft;
}

public class spawnPunkt
{
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
    [SerializeField] private GameObject spawnPoint3;
    [SerializeField] private GameObject spawnPoint4;
}
*/

