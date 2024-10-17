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

    private int level;

    //props
    public float Health { get; set; } = 100;
    public float Maxhealth { get; set; } = 100;

    public float Endurance { get; set; } = 100;
    public float Maxendurance { get; set; } = 100;   

    public float Hunger { get; set;} = 100;
    public float Maxhunger { get; set; } = 100;

    public float Thirst { get; set; } = 100;
    public float Maxthirst { get; set; } = 100;

    public int Level { get; set; } = 1;

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
        level = Level;
    }

    public void LevelUp() {
        Level++;
        HealthUP();
        EnduranceUP();
    }

    public void HealthUP() {
        switch (Level) {
            case 1:; break;
            case 2:; break;
            case 3:; break;
            case 4:; break;
            case 5:; break;
            case 6:; break;
            case 7:; break;
            case 8:; break;
            case 9:; break;
            case 10:; break;

        }
    }

    public void EnduranceUP() { 
     
    }

    public void GetHunger() {
        Hunger = Hunger - 10;
    }

    public void Eat(float Food) {
        Hunger = Hunger + Food;
    }

    public void GetThirst() { 
        Thirst = Thirst - 10;
    }

    public void Drink(float Drink){
        Thirst = Thirst + Drink;    
    }
}



