using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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

    private int level;

    //props
    public float Health { get; set; } = 100;
    public float Maxhealth { get; set; } = 100;

    public float Endurance { get; set; } = 100;
    public float Maxendurance { get; set; } = 100;   

    public float Hunger { get; set;} = 10;
    public float Maxhunger { get; set; } = 10;

    public int Level { get; set; } = 1;

    //constructor

    public PlayerStats() {
        health = Health;
        maxHealth = Maxhealth;
        endurance = Endurance;  
        maxendurance = Maxendurance;    
        hunger = Hunger;    
        maxhunger = Maxhunger;  
        level = Level;
    }

   

    public void LevelUP() {
        switch (Level) {
            case 2: 
                HungerUP(5);
                EnduranceUP(20);
                HealthUP(10);
                Level++;
                break;
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

  

    public void Eat(float Food) {
        Hunger = Hunger + Food;
    }

    public void HungerUP(int AddedHunger)
    {
        Maxhunger += AddedHunger;
    }

    public void HealthUP(int AddedHealth)
    {
        Maxhealth += AddedHealth;
    }
    public void EnduranceUP(int AddedEndurace)
    {
        Maxendurance += AddedEndurace;
    }

    public void En_Regeneration(float Reg){
        if (Endurance > Maxendurance)
        {
            Endurance += Reg * Time.deltaTime;
        }
    }
    public void Hp_Regeneration(float Reg)
    {
        if (Health > Maxhealth) {
            Health += Reg * Time.deltaTime;
        }
    }
    public void LoseEndurance() { 
         Endurance -= 15*Time.deltaTime;
       
    }

}



