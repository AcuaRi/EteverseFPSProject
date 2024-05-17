using UnityEngine;

namespace FPSGame
{
    //사용자 입력 관리
    public class PlayerInputManager : MonoBehaviour
    {
        public static float Horizontal { get; private set; } = 0f;
        public static float Vertical { get; private set; } = 0f;
        // 캐릭터 회전에 사용.
        public static float Turn { get; private set; } = 0f;    // 좌우 드래그.
        public static float Look { get; private set; } = 0f;    // 상하 드래그.
        // 마우스 클릭 이벤트 값.
        public static bool IsFire { get; private set; } = false;

        private void Update()
        {
            //방향키 입력
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
            // 마우스 드래그 값 저장.
            Turn = Input.GetAxis("Mouse X");
            Look = Input.GetAxis("Mouse Y");

            IsFire = Input.GetMouseButton(0);
        }
    }
}


