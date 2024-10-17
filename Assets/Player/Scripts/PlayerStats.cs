using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    // gerneral Stats
    private float health;
    private float maxHealth;
    private float endurance;
    private float maxendurance;

    // HungerSystem
    private float hunger;
    private float maxhunger;

    private float thirst;
    private float maxthirst;

    //props
    public float Health { get; set; } = 100;
    public float Maxhealth { get; set; } = 100;

    public float Endurance { get; set; } = 100;
    public float Maxendurance { get; set; } = 100;   

    public float Hunger { get; set;} = 100;
    public float Maxhunger { get; set; } = 100;

    public float Thirst { get; set; } = 100;
    public float Maxthirst { get; set; } = 100;

    //constructor

    public PlayerStats() {
        health = Health;
        maxHealth = Maxhealth;
        endurance = Endurance;  
        maxendurance = Maxendurance;    
        hunger = Hunger;    
        maxhunger = Maxhunger;  
        thirst = Thirst;    
        maxthirst = Maxthirst;
    }

    public void LevelUp() {
        HealthUP();
        EnduranceUP();
    }

    public void HealthUP() { 
    
    }

    public void EnduranceUP() { 
    
    }

    public void GetHunger() {
    
    }

    public void Eat(float Food) { 
    
    }

    public void GetThirst() { 
    
    }

    public void Drink(float Drink)
    {
        
    }
}



