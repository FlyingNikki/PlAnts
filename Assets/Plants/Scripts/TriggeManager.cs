using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeManager : MonoBehaviour
{
    private string targetTag = "Enemy";
    private Enemy_HP_Manager hpManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            hpManager = other.GetComponent<Enemy_HP_Manager>();
        }
    }
}
