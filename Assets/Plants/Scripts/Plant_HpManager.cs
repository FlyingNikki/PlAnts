using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plant_HpManager : MonoBehaviour
{
    [SerializeField] private ActiveAndPassive_SO _plantsData;
    [SerializeField] private ID_Holder holder;

    [HideInInspector] public bool plant_getHit;

    private int newHP;

    private void Start()
    {
        newHP = _plantsData.PlantsData[holder.ID].HP;
        Debug.Log(newHP);
    }

    private void Update()
    {
        ActivePlants_AI.plant_HP(ref newHP, gameObject, plant_getHit);
    }
}
