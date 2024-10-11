using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Group", menuName = "Create New Enemy Group")]
public class EnemyData_SO : ScriptableObject
{
    public List<EnemyData> enemyData;
}

[System.Serializable]
public class EnemyData
{
    [field: SerializeField] public string Name { get; private set; } = string.Empty;
    [field: SerializeField] public int ID { get; private set; }
    [field: SerializeField] public float Speed { get; private set; } = 10f;
    [field: SerializeField] public float HP { get; private set; }
    //[field: SerializeField] public float 
}
