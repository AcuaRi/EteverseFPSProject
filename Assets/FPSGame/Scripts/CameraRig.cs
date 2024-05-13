using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float damping = 5f;
    
    private Transform refTransform;

    private void Awake()
    {
        refTransform = transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        refTransform.position = Vector3.Lerp(refTransform.position, target.position, damping*Time.deltaTime);
    }
}
