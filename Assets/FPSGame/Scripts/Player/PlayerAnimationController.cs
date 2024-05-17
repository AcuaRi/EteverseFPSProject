using System;
using UnityEngine;


namespace FPSGame
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private CameraRig cameraRig;
        [SerializeField] private float rotationOffset = 0.5f;

        private void Update()
        {
            animator.SetFloat("AimAngle", cameraRig.GetXRotation() * rotationOffset);
        }

        public void SetStateParameter(int state)
        {
            animator.SetInteger("State", state);
        }

        public void SetHVParameter(float h, float v)
        {
            animator.SetFloat("H", PlayerInputManager.Horizontal > 0f ? 1f : PlayerInputManager.Horizontal < 0f ? -1f : 0f);
            animator.SetFloat("V", PlayerInputManager.Vertical > 0f ? 1f : PlayerInputManager.Vertical < 0f ? -1f : 0f);
        }
        
        // 재장전 애니메이션 함수.
        public void OnReload()
        {
            // Reload 트리거 파라미터를 설정.
            animator.SetTrigger("Reload");
        }

        // 재장전 애니메이션이 완료될 때까지 걸리는 시간을 계산하는 함수.
        public float WaitTimeToReload()
        {
            // 세 번째 레이어(=Reload, Index:2)에서 재생되고 있는 
            // 애니메이션 길이 / 재생 속도(배수).
            return animator.GetCurrentAnimatorStateInfo(2).length / animator.GetFloat("ReloadSpeed");
        }
    }
}

