using UnityEngine;

namespace FPSGame
{
    //사용자 입력 관리
    public class PlayerInputManager : MonoBehaviour
    {
        public static float Horizontal { get; private set; } = 0f;
        public static float Vertical { get; private set; } = 0f;

        private void Update()
        {
            //방향키 입력
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
        }
    }
}


