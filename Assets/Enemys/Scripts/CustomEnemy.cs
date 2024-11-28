using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEnemy : MonoBehaviour
{
    [Header("----------Enemy-Data----------")]
    [SerializeField] private EnemyData_SO _enemyData;

    [Space]
    [SerializeField] private bool _walking;
    [SerializeField] private bool _flying;

    [SerializeField] private Transform PartToRotat;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private ID_Holder holder;

    // Walking...
    [SerializeField] private float walkSpeed;

    // Flaying...
    [SerializeField] private bool ComingSoon;

    // private vars...
    private Transform Target_Plant;
    private Transform Target_Base;
    private Transform enemyTransform;
    private bool findTarget = true;

    private void Start()
    {
        enemyTransform = transform;
        rb = GetComponent<Rigidbody>();
        Target_Base = GameObject.FindGameObjectWithTag(_enemyData.enemyData[holder.ID].BaseTag).GetComponent<Transform>();
    }

    private void Update()
    {
        if (_walking)
            Walking();

        if (_flying)
            Flying();
    }

    private void Walking()
    {
        if (findTarget)
        {
            StartCoroutine(FindNewTarget(.3f));
            findTarget = false;
        }

        if (Target_Plant != null)
        {
            EnemyAI.FollowTarget(rb, Target_Plant, _enemyData.enemyData[holder.ID].Speed);
        }
        else if (Target_Plant == null)
        {
            EnemyAI.FollowTarget(rb, Target_Base, _enemyData.enemyData[holder.ID].Speed);
        }
    }

    private void Flying()
    {
        if (findTarget)
        {
            StartCoroutine(FindNewTarget(.3f));
            findTarget = false;
        }

        if (Target_Plant != null)
        {
            //Im flying... to plant
        }
        else if (Target_Plant == null)
        {
            //Im flying.. to base
        }
    }

    private IEnumerator FindNewTarget(float time)
    {
        yield return new WaitForSeconds(time);
        EnemyAI.FindATarget(_enemyData.enemyData[holder.ID].TargetTag, enemyTransform, ref Target_Plant, _enemyData.enemyData[holder.ID].Range);
        findTarget = true;
    }
}
