using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreLayerCollision : MonoBehaviour
{
    [Header("----------Layers(in int)--->")]
    [Tooltip("PLS DONT CHANGE THE NUMS")] [SerializeField] private int Placement;
    [Tooltip("PLS DONT CHANGE THE NUMS")] [SerializeField] private int Enemys;

    private void Start()
    {
        Physics.IgnoreLayerCollision(Placement, Enemys);
    }
}
