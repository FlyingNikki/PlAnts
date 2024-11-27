using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustumEnemy : MonoBehaviour
{
    [Header("----------Enemy-Data----------")]
    [SerializeField] private EnemyData_SO _enemyData;

    [Space]
    [SerializeField] private bool walking;
    [SerializeField] private bool flying;

}
