using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlants_AI : MonoBehaviour
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
    //**********************************FIND A TARGET***************************************
    //**************************************************************************************

    public static void FindATarget(string enemyTag, Transform objectTransform, ref Transform target, float range)
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
    //***************************************Lock On****************************************
    //**************************************************************************************
    public static void LookOn(Transform target, Transform objectTransform, Transform partToRotat, float rotationSpeed)
    {
        Vector3 dir = target.position - objectTransform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotat.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        partToRotat.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    //**************************************************************************************
    //*************************************** HP *******************************************
    //**************************************************************************************
    public static void plant_HP(ref int hp, GameObject plant, bool getHited)
    {
        if (getHited)
        {
            hp--;
            getHited = false;
        }

        if (hp <= 0)
        {
            Debug.Log("Plant get destroyed!");
            Destroy(plant, .1f);
            return;
        }
    }
}
