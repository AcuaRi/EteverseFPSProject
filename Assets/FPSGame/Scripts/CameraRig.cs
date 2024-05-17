using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FPSGame;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    [Header("Camera Rig")]
    [SerializeField] private Transform target;
    [SerializeField] private float damping = 5f;
    [SerializeField] private float rotationDamping = 5f;
    
    private Transform refTransform;
    
    [Header("Camera UpDown")]
    // 상하 회전에 사용하는 변수.
    [SerializeField] private Transform cameraTransform;     // 메인 카메라 트랜스폼.
    [SerializeField] private float minAngle = -30f;         // 상하 회전 최소 각도 값.
    [SerializeField] private float maxAngle = 40f;          // 상하 회전 최대 각도 값.
    [SerializeField] private float xRotation = 0f;          // 카메라의 x축 누적 회전을 계산하기 위한 변수.

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
        refTransform.rotation = Quaternion.Lerp(refTransform.rotation, target.rotation, rotationDamping*Time.deltaTime);

        Look();
    }

    private void Look()
    {
        // 하고 싶은 일: 카메라 X 회전을 위로 아래로 적용하기.
        // 카메라 트랜스폼 | 마우스 드래그 값(Y).

        // 마우스 위/아래 드래그 값을 -1에서 1 사이의 값으로 고정.
        float mouseY = Mathf.Clamp(PlayerInputManager.Look, -1f, 1f);

        // 마우스 드래그 값으로 X축 회전 누적.
        xRotation -= mouseY;

        // 회전 값 고정.
        xRotation = Mathf.Clamp(xRotation, minAngle, maxAngle);

        // 카메라의 오일러 회전 값 가져오기.
        Vector3 targetRotation = cameraTransform.localRotation.eulerAngles;
        targetRotation.x = xRotation;

        // 오일러 회전을 쿼터니언으로 변환한 후에 카메라 로컬 회전에 설정.
        cameraTransform.localRotation = Quaternion.Euler(targetRotation);
    }

    public float GetXRotation()
    {
        return xRotation;
    }
}
