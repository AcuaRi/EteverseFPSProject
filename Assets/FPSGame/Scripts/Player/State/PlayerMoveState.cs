using System;
using UnityEngine;

namespace FPSGame
{
    public class PlayerMoveState : PlayerState
    {
        [SerializeField] private float moveSpeed = 5f;

        protected override void Update()
        {
            base.Update();

            Vector3 direction = new Vector3(PlayerInputManager.Horizontal, 0, PlayerInputManager.Vertical);
            refTransform.position += moveSpeed * Time.deltaTime * direction.normalized;
        }
    }
}
