using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Group", menuName = "Create New Enemy Group")]
public class EnemyData_SO : ScriptableObject
{
    [Header("--------> Enemy Data List")]
    [Tooltip("List of enemies with their respective attributes")]
    public List<EnemyData> enemyData;
}

[System.Serializable]
public class EnemyData
{
    [field: SerializeField] public string Name {  get; private set; } = string.Empty;
    [field: SerializeField] public string Tag {  get; private set; } = string.Empty;
    [field: SerializeField] public string TargetTag {  get; private set; } = string.Empty;
    [field: SerializeField] public string BaseTag {  get; private set; } = "Base";

    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public int HP { get; private set; }
    [field: SerializeField] public int ID { get; private set; }
    [field: SerializeField] public float Range { get; private set; } = 7;
    [field: SerializeField] public float Speed { get; private set; } = 10;
    [field: SerializeField] public float RotationSpeed { get; private set; } = 15;

    [field: SerializeField] public float TimeBetweenAttacks { get; private set; }
}
