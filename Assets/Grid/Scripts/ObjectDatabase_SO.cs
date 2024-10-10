using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectDatabase_SO : ScriptableObject
{
    public List<ObjectData> objectData;
}

[System.Serializable]
public class ObjectData
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int ID { get; private set; }
    [field: SerializeField] public Vector2Int Size { get; private set; } = Vector2Int.one;
    [field: SerializeField] public GameObject Perfab {  get; private set; }
}

