using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //**************************************************************************************
    //************************************FIND A TARGET*************************************
    //**************************************************************************************
    public static void FindATarget(string plantsTag, Transform objectTransform, ref Transform target, float range)
    {
        GameObject[] plants = GameObject.FindGameObjectsWithTag(plantsTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlant = null;

        foreach (GameObject plant in plants)
        {
            float distanceToPlant = Vector3.Distance(objectTransform.position, plant.transform.position);
            if (distanceToPlant < shortestDistance)
            {
                shortestDistance = distanceToPlant;
                nearestPlant = plant;
            }
        }

        if (nearestPlant != null && shortestDistance <= range)
        {
            target = nearestPlant.transform;
        }
        else
        {
            target = null;
        }
    }

    //**************************************************************************************
    //************************************FOLLOW TARGET*************************************
    //**************************************************************************************
    public static void FollowTarget(Rigidbody enemyRB, Transform target, float speeed)
    {
        Vector3 direction = (target.position - enemyRB.transform.position).normalized;
        enemyRB.velocity = direction * speeed;
    }

    //**************************************************************************************
    //***********************************LOOK AT TARGET*************************************
    //**************************************************************************************
    public static void LookAtTarget (Transform enemyTransform, Transform target, float rotationSpeed)
    {
        Vector3 direction = (target.position - enemyTransform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        enemyTransform.rotation = Quaternion.Slerp(enemyTransform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}
