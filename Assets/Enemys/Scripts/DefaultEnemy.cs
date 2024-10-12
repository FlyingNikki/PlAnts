using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : MonoBehaviour
{
    [Header("----------Enemy/Setup----------")]
    [SerializeField] private int ID = 0;
    [SerializeField] private EnemyData_SO _enemyData;

    private Transform target_Plant;
    private Transform target_Base;
    private Transform enemyTransform;
    private Rigidbody rb;
    private bool findTarget = true;

    private void Start()
    {
        enemyTransform = transform;
        rb = GetComponent<Rigidbody>();
        target_Base = GameObject.FindGameObjectWithTag(_enemyData.enemyData[ID].BaseTag).GetComponent<Transform>();
    }

    private void Update()
    {
        if (findTarget)
        {
            StartCoroutine(FindNewTarget(.3f));
            findTarget = false;
        }

        if (target_Plant != null)
        {
            EnemyAI.FollowTarget(rb, target_Plant, _enemyData.enemyData[ID].Speed);
        }
        else if (target_Plant == null)
        {
            EnemyAI.FollowTarget(rb, target_Base, _enemyData.enemyData[ID].Speed);
        }
    }

    private IEnumerator FindNewTarget(float time)
    {
        yield return new WaitForSeconds(time);

        EnemyAI.FindATarget(_enemyData.enemyData[ID].TargetTag, enemyTransform, ref target_Plant, _enemyData.enemyData[ID].Range);

        findTarget = true;
    }
}