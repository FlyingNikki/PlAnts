using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP_Manager : MonoBehaviour
{
    [SerializeField] private EnemyData_SO _enemyData_SO;

    [HideInInspector] public int enemyHP;

    private ID_Holder _ID;

    private void Start()
    {
        _ID = GetComponent<ID_Holder>();

        
    }

}
