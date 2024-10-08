using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlants_Manager : MonoBehaviour
{
    //**************************************************************************************
    //**********************************Shooting System*************************************
    //**************************************************************************************
    public static IEnumerator ShootingSystem(float timeBetweenShots, GameObject bullet, Transform point, float bulletDestroyTime)
    {
        while (true)
        {
            GameObject new_Bullet = Instantiate(bullet, point.position, point.rotation);
            Destroy(new_Bullet, bulletDestroyTime);

            yield return new WaitForSeconds(timeBetweenShots);
        }
    }

    //**************************************************************************************
    //**********************************Range System****************************************
    //**************************************************************************************

    public static void RangeSystem(string enemyTag, Transform objectTransform, ref Transform target, float range)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(objectTransform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    //**************************************************************************************
    //**********************************Look On System**************************************
    //**************************************************************************************
    public static void LookOn(Transform target, Transform objectTransform, Transform partToRotat, float rotationSpeed)
    {
        Vector3 dir = target.position - objectTransform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotat.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        partToRotat.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

}
