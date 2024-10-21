using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : MonoBehaviour
{
    [Header("----------Enemy/Setup----------")]
    [SerializeField] private EnemyData_SO _enemyData;

    private Transform target_Plant;
    private Transform target_Base;
    private Transform enemyTransform;
    private Rigidbody rb;
    private bool findTarget = true;

    private ID_Holder _ID;
    private int Id;

    private void Start()
    {
        enemyTransform = transform;
        rb = GetComponent<Rigidbody>();
        _ID = GetComponent<ID_Holder>();
        Id = _ID.ID;
        target_Base = GameObject.FindGameObjectWithTag(_enemyData.enemyData[_ID.ID].BaseTag).GetComponent<Transform>();
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
            EnemyAI.FollowTarget(rb, target_Plant, _enemyData.enemyData[Id].Speed);
        }
        else if (target_Plant == null)
        {
            EnemyAI.FollowTarget(rb, target_Base, _enemyData.enemyData[Id].Speed);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _enemyData.enemyData[Id].Range);
    }

    private IEnumerator FindNewTarget(float time)
    {
        yield return new WaitForSeconds(time);

        EnemyAI.FindATarget(_enemyData.enemyData[Id].TargetTag, enemyTransform, ref target_Plant, _enemyData.enemyData[Id].Range);

        findTarget = true;
    }
}
