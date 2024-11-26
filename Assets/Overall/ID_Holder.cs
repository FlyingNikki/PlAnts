using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID_Holder : MonoBehaviour
{
    public int ID;

    private void Start()
    {
        if (ID < 0)
            Debug.LogError($"The ID: {ID} is NEGATIVE!");
    }
}
