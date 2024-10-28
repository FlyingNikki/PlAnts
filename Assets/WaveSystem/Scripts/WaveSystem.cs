using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSystem : MonoBehaviour
{
    [Header("-----------SpawnPoints--->")]
    [SerializeField] private Transform[] spawnPoints;

    [Space]
    [Header("-----------SpawnInfos--->")]
    [SerializeField] private List<spawnInfo> Waves;

    [HideInInspector] public int aliveEnemys;

    //private vars...
    private int spawnPoint_ID;
    private int enemyPoint_ID;
    private int lastSpawnPoint_ID = -1;
    private int wave_ID = -1;

    //temporary vars...
    private bool nightTime = false;
    private bool waveEnds = false;

    private void Start()
    {
        nightTime = true;
        wave_ID++;
        aliveEnemys = 0;
        StartCoroutine(EnemyGenerator());
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space) && !nightTime)
        {
            nightTime = true;
            wave_ID++;
            aliveEnemys = 0;
            StartCoroutine(EnemyGenerator());
        }
        */

        if (aliveEnemys <= 0 && !nightTime && waveEnds)
            Debug.Log("CONGRATULATIONA! U SURVIVED THIS NIGHT!");
    }

    private IEnumerator EnemyGenerator()
    {
        for (int i = 0; i < Waves[wave_ID].amoutOfEnemys; i++)
        {
            GenrateRandomePoints();
            yield return new WaitForSeconds(Waves[wave_ID].timeBetweenSpawn);
        }

        //Debug.Log("Loop Ends");
        
        while (aliveEnemys > 0)
        {
            yield return null;
        }

        waveEnds = true;
        nightTime = false;

    }

    private void GenrateRandomePoints()
    {
        spawnPoint_ID = Random.Range(0, spawnPoints.Length);
        if (spawnPoint_ID == lastSpawnPoint_ID)
        {
            spawnPoint_ID = (spawnPoint_ID + 1) % spawnPoints.Length; // Move to the next spawn point or wrap around
        }

        lastSpawnPoint_ID = spawnPoint_ID;

        enemyPoint_ID = Random.Range(0, Waves[wave_ID].Enemyes.Length);

        Instantiate(Waves[wave_ID].Enemyes[enemyPoint_ID], spawnPoints[spawnPoint_ID].transform.position, spawnPoints[spawnPoint_ID].transform.rotation);
        aliveEnemys++;
    }
}

[System.Serializable]
public class spawnInfo
{
    [field: SerializeField] public string wave {  get; private set; }
    [field: SerializeField] public float timeBetweenSpawn {  get; private set; }
    [field: SerializeField] public int amoutOfEnemys {  get; private set; }
    [field: SerializeField] public GameObject[] Enemyes {  get; private set; }
}

