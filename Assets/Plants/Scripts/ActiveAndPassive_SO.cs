using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant Group", menuName = "Create New Plant Group")]
public class ActiveAndPassive_SO : ScriptableObject
{
    public List<PlantsData> PlantsData;
}

[System.Serializable]
public class PlantsData
{
    // all plants use it...
    [field: SerializeField] public string Name {  get; private set; }
    [field: SerializeField] public string Tag {  get; private set; }
    [field: SerializeField] public int ID {  get; private set; }
    [field: SerializeField] public int HP {  get; private set; }
    [field: SerializeField] public int Cost {  get; private set; }
    [field: SerializeField] public int Range { get; private set; } = 5;
    [field: SerializeField] public float RotationSpeed { get; private set; } = 10;
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float timeBetweenAttacks {  get; private set; }
}
