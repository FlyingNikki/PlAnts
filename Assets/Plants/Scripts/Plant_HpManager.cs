using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plant_HpManager : MonoBehaviour
{
    [SerializeField] private ActivePlants_AI activePlant_AI;
    [SerializeField] private ActiveAndPassive_SO _plantsData;
    [SerializeField] private ID_Holder holder;

    [HideInInspector] public bool getHit;

    private void Update()
    {
        //activePlant_AI.plant_HP(_plantsData.PlantsData[holder.ID].HP, gameObject, getHit);
    }
}
