using UnityEngine;


namespace FPSGame
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void SetStateParameter(int state)
        {
            animator.SetInteger("State", state);
        }

        public void SetHVParameter(float h, float v)
        {
            animator.SetFloat("H", PlayerInputManager.Horizontal > 0f ? 1f : PlayerInputManager.Horizontal < 0f ? -1f : 0f);
            animator.SetFloat("V", PlayerInputManager.Vertical > 0f ? 1f : PlayerInputManager.Vertical < 0f ? -1f : 0f);
        }
    }
}

