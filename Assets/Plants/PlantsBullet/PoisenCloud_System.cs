using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisenCloud_System : MonoBehaviour
{
    //private int Range = 3;
    private string enemyTag = "Enemy";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {

        }
    }
}
