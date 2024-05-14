using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace FPSGame
{
    public class PlayerState : MonoBehaviour
    {
        protected Transform refTransform;
        
        //상태 진입
        protected virtual void OnEnable()
        {
            if (refTransform == null)
            {
                refTransform = transform;
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


