using System.Collections;
using UnityEngine;

namespace FPSGame.Scripts
{
    //코루틴 유한상태기계(FSM)
    public class PlayerControlCoroutineBased : MonoBehaviour
    {
        //상태 종류
        public enum State
        {
            Idle,
            Move
        }

        ////필드
        // 상태.
        [SerializeField] private State currentState = State.Idle;
        // 이동 속도.
        [SerializeField] private float moveSpeed = 5f;
        // Animator 컴포넌트 변수.
        [SerializeField] private Animator refAnimator;
        // 트랜스폼 컴포넌트 참조 변수.
        [SerializeField] private Transform refTransform;

        //상태 설정 함수
        public void SetState(State newState)
        {
            currentState = newState;
            refAnimator.SetInteger("State",(int)currentState);
        }

        private void Awake()
        {
            refTransform = transform;
            refAnimator = GetComponentInChildren<Animator>();
            StartCoroutine(FSMStart());

        }

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
                
            if (horizontal ==0 && vertical ==0)
            {
                SetState(State.Idle);
            }
            else
            {
                SetState(State.Move);
            }
        }

        //FSM 함수
        IEnumerator FSMStart()
        {
            while (true)
            {
                yield return StartCoroutine(currentState.ToString());
            }
        }
        
        //Idle 함수
        IEnumerator Idle()
        {
            while (currentState == State.Idle)
            {
                yield return null;
            }
        }
        
        //Move 함수
        IEnumerator Move()
        {
            while (currentState == State.Move)
            {
                yield return null;
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
                
                refAnimator.SetFloat("H", horizontal > 0f ? 1f : horizontal < 0f ? -1f : 0f);
                refAnimator.SetFloat("V", vertical > 0f ? 1f : vertical < 0f ? -1f : 0f);
                
                refTransform.position += moveSpeed * Time.deltaTime * new Vector3(horizontal, 0, vertical).normalized;
            }
        }
        
    }
}
