using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace FPSGame
{
    public class PlayerState : MonoBehaviour
    {
        protected Transform refTransform;

        [SerializeField] private CharacterController characterController;
        
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
            
        }

        //상태 종료
        protected virtual void OnDisable()
        {
            
        }
    }
}


