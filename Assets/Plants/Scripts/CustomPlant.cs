using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPlant : MonoBehaviour
{
    [Header("----------Plant-Data----------")]
    [SerializeField] private ActiveAndPassive_SO _plantData;

    [Space]
    [SerializeField] private bool _shooting;

    [SerializeField] private Transform shotingPoint;
    [SerializeField] private int plantID;
    [SerializeField] private string enemyTag;
    [SerializeField] private Transform OrientationPoint;
    [SerializeField] private Transform partToRotat;

    private Coroutine shootingCoroutine;
    private bool findTarget = true;
    private Transform target;

    private void Update()
    {
        if (_shooting)
            Shooting();

        ActivePlants_AI.LookOn(target, OrientationPoint, partToRotat, _plantData.PlantsData[plantID].RotationSpeed);
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

    private void StartShooting()
    {
        // Ensure that shooting is not already in progress
        if (shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(ActivePlants_AI.ShootingSystem(
                _plantData.PlantsData[plantID].timeBetweenAttacks,
                _plantData.PlantsData[plantID].bullet,
                shotingPoint,
                _plantData.PlantsData[plantID].bulletDestroyTime
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

    private IEnumerator FindNewTarget(float time)
    {
        yield return new WaitForSeconds(time);

        ActivePlants_AI.FindATarget(enemyTag, OrientationPoint, ref target, _plantData.PlantsData[plantID].Range);

        findTarget = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _plantData.PlantsData[plantID].Range);
    }
}
