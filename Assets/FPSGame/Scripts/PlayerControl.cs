using UnityEngine;

namespace FPSGame.Scripts
{
    public class PlayerControl : MonoBehaviour
        {
            public enum State
            {
                Idle,
                Move
            }
            
            // 상태 설정
            [SerializeField] private State currentState = State.Idle;
            // 이동 속도.
            [SerializeField] private float moveSpeed = 5f;
            // Animator 컴포넌트 변수.
            [SerializeField] private Animator refAnimator;
            
            // 트랜스폼 컴포넌트 참조 변수.
            private Transform refTransform;
    
            private void Awake()
            {
                // 트랜스폼 참조 저장.
                refTransform = transform;
                refAnimator = GetComponentInChildren<Animator>();
            }
    
            private void Update()
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
                
                refAnimator.SetFloat("H", horizontal > 0f ? 1f : horizontal < 0f ? -1f : 0f);
                refAnimator.SetFloat("V", vertical > 0f ? 1f : vertical < 0f ? -1f : 0f);
                
                if (horizontal ==0 && vertical ==0)
                {
                    currentState = State.Idle;
                }
                else
                {
                    currentState = State.Move;
                }
                
                refAnimator.SetInteger("State",(int)currentState);
                refTransform.position += moveSpeed * Time.deltaTime * new Vector3(horizontal, 0, vertical).normalized;
            }
        }
}



