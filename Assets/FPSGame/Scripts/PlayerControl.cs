using UnityEngine;

namespace FPSGame
{
    public class PlayerControl : MonoBehaviour
        {
            // 이동 속도.
            [SerializeField] private float moveSpeed = 5f;
            
            // 트랜스폼 컴포넌트 참조 변수.
            private Transform refTransform;
    
            private void Awake()
            {
                // 트랜스폼 참조 저장.
                refTransform = transform;
            }
    
            private void Update()
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");

                refTransform.position += moveSpeed * Time.deltaTime * new Vector3(horizontal, 0, vertical).normalized;
                
            }
        }
}



