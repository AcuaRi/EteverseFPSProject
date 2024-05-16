using UnityEngine;

namespace FPSGame
{
    // 플레이어가 발사하는 탄약을 제어하는 스크립트.
    public class BulletController : MonoBehaviour
    {
        // 충돌한 지점에 보여줄 데칼(Decal) 효과.
        [SerializeField] private GameObject collisionDecal;

        private void OnCollisionEnter(Collision collision)
        {
            // 충돌한 물체의 레이어를 확인. Wall이면 탄흔 표시.
            //if (collision.gameObject.layer == 1<<6)
            if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                // 충돌 지점 받아오기.
                ContactPoint contact = collision.contacts[0];

                // 데칼을 제대로 보여주기 위한 회전 설정.
                Quaternion rotation = Quaternion.LookRotation(contact.normal);

                // 데칼 게임 오브젝트 생성.
                Instantiate(collisionDecal, contact.point, rotation);
            }

            // 이 게임 오브젝트(탄약)는 제거.
            Destroy(gameObject);
        }
    }
}