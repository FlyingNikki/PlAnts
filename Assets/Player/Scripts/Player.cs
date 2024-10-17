using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    PlayerStats stats;
    Player shamane;
    bool dead;
    


    void Start()
    {
        shamane = this;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        dead = IsDead();

    }

    //Movement
    public void Movement() { 
     
    }

    public void DayOver() {
        stats.GetThirst();
        stats.GetHunger();
    }

    public bool IsDead() {
        if (stats.Hunger <= 0 || stats.Health <= 0 || stats.Thirst <= 0) { 
            return true; 
        }
        else {
            return false;
        }
        
    }

  
}
