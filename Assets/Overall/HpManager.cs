using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    [SerializeField] private ActiveAndPassive_SO _plantsData;
    [SerializeField] private EnemyData_SO _enemyData;

    [Space]
    [SerializeField] private bool plant;
    [SerializeField] private bool enemy;

    [HideInInspector] public bool plant_getHit;
    [HideInInspector] public bool enemy_getHit;
    [HideInInspector] public float getedDamage;

    private float Plant_newHP;
    private float Enemy_newHP;
    private ID_Holder holder;

    private void Start()
    {
        Plant_newHP = _plantsData.PlantsData[holder.ID].HP;
        Enemy_newHP = _enemyData.enemyData[holder.ID].HP;
        
        holder = GetComponent<ID_Holder>();
    }

    private void Update()
    {
        if (plant && _plantsData != null)
            plant_HP_Manager(ref Plant_newHP, gameObject, plant_getHit, getedDamage);

        if (enemy && _enemyData != null)
            enemy_HP_Manager(ref Plant_newHP, gameObject, enemy_getHit, getedDamage);
    }

    private void plant_HP_Manager(ref float hp, GameObject plant, bool getHited, float getedDamage)
    {
        if (getHited)
        {
            hp -= getedDamage;
            getHited = false;
        }

        if (hp <= 0)
        {
            Debug.Log("Enemy get destroyed!");
            Destroy(plant, .1f);
            return;
        }
    }

    private void enemy_HP_Manager(ref float hp, GameObject plant, bool getHited, float getedDamage)
    {
        if (getHited)
        {
            hp -= getedDamage;
            getHited = false;
        }

        if (hp <= 0)
        {
            Debug.Log("Enemy get destroyed!");
            Destroy(plant, .1f);
            return;
        }
    }
}
