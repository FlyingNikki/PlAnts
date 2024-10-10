using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPlant : MonoBehaviour
{
    [Header("----------Plant-Data----------")]
    [SerializeField] private ActiveAndPassive_SO _plantData;

    [Space]
    [Header("---------->")]
    [SerializeField] private Transform shotingPoint;
    [SerializeField] private int plantID;
    [SerializeField] private float Range;
    [SerializeField] private string enemyTag;
    [SerializeField] private Transform OrientationPoint;
    [SerializeField] private Transform partToRotat;

    private Coroutine shootingCoroutine;
    private bool findTarget = true;
    private Transform target;

    private void Update()
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

        ActivePlants_Manager.LookOn(target, OrientationPoint, partToRotat, _plantData.PlantsData[plantID].RotationSpeed);
    }

    private void StartShooting()
    {
        // Ensure that shooting is not already in progress
        if (shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(ActivePlants_Manager.ShootingSystem(
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private IEnumerator FindNewTarget(float time)
    {
        yield return new WaitForSeconds(time);

        ActivePlants_Manager.RangeSystem(enemyTag, OrientationPoint, ref target, Range);

        findTarget = true;
    }

}
