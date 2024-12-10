using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharMover : MonoBehaviour
{
    // Start is called before the first frame update

    private InputHandler _input;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float rotateSpeed = 5;


    [SerializeField] private bool rotateM;

    [SerializeField] private Camera Camera;
    void Awake()
    {
       _input = GetComponent<InputHandler>();
    }

    private void Start()
    {
        Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        //move
        var richtungVec = Move(targetVector);


        //rotate

        if (!rotateM)
        {
            Rotate(richtungVec);
        }
        else {
            RotateMouse();
        }

        
    }

    private void RotateMouse()
    {
        Ray ray = Camera.ScreenPointToRay(_input.MousePosition);

        if (Physics.Raycast(ray,out RaycastHit hitInfo, maxDistance:300f)) {

            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }


    }

    private void Rotate(Vector3 richtungVec)
    {

        if (richtungVec.magnitude == 0) {
            return;
        }
        var rotation = Quaternion.LookRotation(richtungVec);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    private Vector3 Move(Vector3 targetVector)
    {
        var Speed = speed * Time.deltaTime;

       targetVector = Quaternion.Euler(0,Camera.gameObject.transform.eulerAngles.y,0)* targetVector;
       
       var targetpos = transform.position + targetVector * speed;
       transform.position = targetpos;

        return targetVector;
    }
}
