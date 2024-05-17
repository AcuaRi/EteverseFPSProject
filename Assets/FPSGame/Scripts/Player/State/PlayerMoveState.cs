using System;
using UnityEngine;

namespace FPSGame
{
    public class PlayerMoveState : PlayerState
    {
        //[SerializeField] private float moveSpeed = 5f;

        protected override void Update()
        {
            base.Update();

            //Vector3 direction = new Vector3(PlayerInputManager.Horizontal, 0, PlayerInputManager.Vertical);
            Vector3 direction = refTransform.right * PlayerInputManager.Horizontal +
                                refTransform.forward * PlayerInputManager.Vertical;
            
            
            // 캐릭터 컨트롤러를 사용한 이동.
            characterController.Move(  data.moveSpeed * Time.deltaTime * direction.normalized);
            
            //refTransform.position += moveSpeed * Time.deltaTime * direction.normalized;
        }
    }
}
