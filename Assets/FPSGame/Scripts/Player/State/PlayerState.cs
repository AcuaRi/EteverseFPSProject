using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace FPSGame
{
    public class PlayerState : MonoBehaviour
    {
        protected Transform refTransform;

        [SerializeField] protected CharacterController characterController;
        //[SerializeField] protected float rotationSpeed = 360f;

        protected PlayerData data;

        public void SetData(PlayerData data)
        {
            this.data = data;
        }
        
        //상태 진입
        protected virtual void OnEnable()
        {
            if (refTransform == null)
            {
                refTransform = transform;
            }
            
            // 컴포넌트 초기화.
            if (characterController == null)
            {
                characterController = GetComponent<CharacterController>();
            }
        }


        //상태 업데이트
        protected virtual void Update()
        {
            Vector3 gravity = new Vector3(0, -9.8f, 0);
            characterController.Move(gravity * Time.deltaTime);
            
            // 좌우 캐릭터 회전 처리.
            Vector3 rotation = new Vector3(0f, PlayerInputManager.Turn * data.rotationSpeed * Time.deltaTime, 0f);

            // 회전 적용.
            refTransform.Rotate(rotation);
        }

        //상태 종료
        protected virtual void OnDisable()
        {
            
        }
    }
}


