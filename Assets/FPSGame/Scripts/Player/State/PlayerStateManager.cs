using System;
using UnityEngine;


namespace FPSGame
{
    public class PlayerStateManager : MonoBehaviour
    {
        public enum State
        {
            Idle,
            Move,
            None
        }

        [SerializeField] private State currentState = State.None;
        [SerializeField] private PlayerState[] states;
        [SerializeField] private PlayerAnimationController animationController;
        // 플레이어 데이터.
        [SerializeField] private PlayerData data;

        private void OnEnable()
        {
            // 처음 시작할 스테이트 설정.
            SetState(State.Idle);

            // 각 스테이트에 데이터 전파.
            foreach (PlayerState state in states)
            {
                state.SetData(data);
            }
        }

        public void SetState(State newState)
        {
            if (currentState == newState) return;
            
            if(currentState != State.None) states[(int)currentState].enabled = false;
            
            states[(int)newState].enabled = true;
            
            currentState = newState;
            
            animationController.SetStateParameter((int)currentState);
        }
        
        private void Update()
        {
            if (PlayerInputManager.Horizontal == 0f 
                && PlayerInputManager.Vertical == 0f)
            {
                SetState(State.Idle);
            }
            else
            {
                SetState(State.Move);
                animationController.SetHVParameter(PlayerInputManager.Horizontal, PlayerInputManager.Vertical);
            }
        }
    }
}

