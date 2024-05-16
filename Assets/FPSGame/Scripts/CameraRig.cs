using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float damping = 5f;
    [SerializeField] private float rotationDamping = 5f;
    
    private Transform refTransform;

    private void Awake()
    {
        refTransform = transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // 커서 락.
        Cursor.lockState = CursorLockMode.Locked;
    }
    

    private void LateUpdate()
    {
        refTransform.position = Vector3.Lerp(refTransform.position, target.position, damping*Time.deltaTime);
        //회전
        refTransform.rotation = Quaternion.Lerp(refTransform.rotation, target.rotation, damping*Time.deltaTime);
    }
}
