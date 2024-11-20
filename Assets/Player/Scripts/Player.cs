using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    PlayerStats stats;
    Player shamane;
    bool dead;
    float speed;

    //test
    public float Ausdauer;


    void Start()
    {
        shamane = this;
        stats = new PlayerStats();
        speed = 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        stats.En_Regeneration(2);

        //test
        Ausdauer = stats.Endurance;
    }

    //Movement
    public void Movement() {
      

        //runnning
        Running();
     

        if (Input.GetKey(KeyCode.D)) {
            transform.position += new Vector3(5,0,0) * speed * Time.deltaTime;
            transform.position.Normalize();
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -5) * speed * Time.deltaTime;
            transform.position.Normalize();
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 5) * speed * Time.deltaTime;
            transform.position.Normalize();
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-5, 0, 0) * speed * Time.deltaTime;
            transform.position.Normalize();
        }
    }

    public void Running() {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 1.5f;

        }
        else {
            speed = 0.75f;
        }
   
    }

    

   

  
}
