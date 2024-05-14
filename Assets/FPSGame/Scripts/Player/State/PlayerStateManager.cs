using UnityEngine;


namespace FPSGame
{
    public class PlayerStateManager : MonoBehaviour
    {
        public enum State
        {
            Idle,
            Move
        }

        [SerializeField] private State currentState = State.Idle;
        [SerializeField] private PlayerState[] states;
        [SerializeField] private PlayerAnimationController animationController;

        public void SetState(State newState)
        {
            if (currentState == newState) return;
            
            states[(int)currentState].enabled = false;
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

