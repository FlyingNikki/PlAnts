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
    [SerializeField] private List<spawnInfo> spawnInfo;

    //private vars...
    private int spawnPoint_ID;
    private int enemyPoint_ID;
    private int wave_ID;

    private IEnumerator GenrateRandomePoints()
    {
        wave_ID++;
        spawnPoint_ID = Random.Range(0, spawnPoints.Length);
        enemyPoint_ID = Random.Range(0, spawnInfo[wave_ID].Enemyes.Length);

        Instantiate(spawnInfo[wave_ID].Enemyes[enemyPoint_ID], spawnPoints[spawnPoint_ID]);
        yield return new WaitForSeconds(spawnInfo[wave_ID].timeBetweenWaves);
    }
}

[System.Serializable]
public class spawnInfo
{
    [field: SerializeField] public string wave {  get; private set; }
    [field: SerializeField] public float timeBetweenWaves {  get; private set; }
    [field: SerializeField] public GameObject[] Enemyes {  get; private set; }
}

