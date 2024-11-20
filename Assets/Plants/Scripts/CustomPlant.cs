using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPlant : MonoBehaviour
{
    [Header("----------Plant-Data----------")]
    [SerializeField] private ActiveAndPassive_SO _plantData;

    [Space]
    [SerializeField] private bool _shooting;
    [SerializeField] private bool _full_AOE;

    [SerializeField] private string enemyTag;
    [SerializeField] private Transform OrientationPoint;
    [SerializeField] private Transform partToRotat;

    // Shooting...
    [SerializeField] private Transform shotingPoint;
    [SerializeField] private float BulletDestroyTime;
    [SerializeField] private GameObject _Bullet;


    // Full AOE...
    [SerializeField] private GameObject gas;
    [SerializeField] private Transform startPoint;
    [SerializeField] private float gasDestroyTime;


    private Coroutine shootingCoroutine;
    private Coroutine full_AOE_Coroutine;
    private ID_Holder plantID;
    private bool findTarget = true;
    private Transform target;

    private void Start()
    {
        plantID = GetComponent<ID_Holder>();
    }

    private void Update()
    {
        if (_shooting)
            Shooting();

        if (_full_AOE)
            Full_AOE();

        ActivePlants_AI.LookOn(target, OrientationPoint, partToRotat, _plantData.PlantsData[plantID.ID].RotationSpeed);
    }

    private void Full_AOE()
    {
        if (findTarget)
        {
            StartCoroutine(FindNewTarget(.5f));
            findTarget = false;
        }

        if (target != null)
        {
            StartFull_AOE_Attack();
        }
        else if (target == null)
        {
            StopFull_AOR_Attack();
            return;
        }
        
    }

    private void Shooting()
    {
        if (findTarget)
        {
            StartCoroutine(FindNewTarget(.5f));
            findTarget = false;
        }

        if (target != null)
        {
            StartShooting();
        }
        else if (target == null)
        {
            StopShooting();
            return;
        }
    }

    //-------------SHOOTING----------->
    private void StartShooting()
    {
        // Ensure that shooting is not already in progress
        if (shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(ActivePlants_AI.ShootingSystem(
                _plantData.PlantsData[plantID.ID].timeBetweenAttacks,
                _Bullet,
                shotingPoint,
                BulletDestroyTime
            ));
        }
    }

    private void StopShooting()
    {
        // Stop the shooting coroutine if it is running
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }

    //-------------AOE----------->
    private void StartFull_AOE_Attack()
    {
        if (full_AOE_Coroutine == null)
        {
            full_AOE_Coroutine = StartCoroutine(ActivePlants_AI.full_AOE(startPoint, _plantData.PlantsData[plantID.ID].timeBetweenAttacks,
                gas,
                gasDestroyTime));
        }
    }

    private void StopFull_AOR_Attack()
    {
        if (full_AOE_Coroutine != null)
        {
            StopCoroutine(full_AOE_Coroutine);
            full_AOE_Coroutine = null;
        }
    }

    private IEnumerator FindNewTarget(float time)
    {
        yield return new WaitForSeconds(time);

        ActivePlants_AI.FindATarget(enemyTag, OrientationPoint, ref target, _plantData.PlantsData[plantID.ID].Range);

        findTarget = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (plantID != null)
            Gizmos.DrawWireSphere(transform.position, _plantData.PlantsData[plantID.ID].Range);
    }
}
