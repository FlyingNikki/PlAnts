using System.Collections;
using UnityEngine;

public class Wave : MonoBehaviour
{

    [SerializeField] private Transform[] spownPoints;
    [SerializeField] private float countdown;

    public static bool readyToCountdown;
    public static int currentWaveIndex = 0;
    public Waves[] waves;
    public int randomSpawn;

    public spawnPunkt[] spawnPoints;

    void Start()
    {
        readyToCountdown = true;
        for (int i = 0; i < waves.Length; i++)
        {
            Waves.enemiesLeft = waves[i].enemies.Length;
        }
    }

    private void Spawnwave()
    {

        for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
        {
            StartCoroutine(RandomSpawnManager(.5f));
        }
    }

    private IEnumerator RandomSpawnManager(float time)
    {
        switch (randomSpawn)
        {
            case 1:
                //Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoints[0]);

                //enemy.transform.SetParent(spawnPoint1.transform);
                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
                break;

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
            //StartCoroutine(Spawnwave());
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
    [HideInInspector]
    public static int enemiesLeft;
}

public class spawnPunkt
{
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
    [SerializeField] private GameObject spawnPoint3;
    [SerializeField] private GameObject spawnPoint4;
}

