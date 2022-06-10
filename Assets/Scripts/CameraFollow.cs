using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;
    private Vector3 _distance;


    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _distance = transform.position;
    }

    void LateUpdate()
    {
        this.transform.position=Vector3.Lerp(this.transform.position,target.transform.position+_distance,Time.deltaTime);
        
    }
}
