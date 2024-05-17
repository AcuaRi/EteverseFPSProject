using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace FPSGame
{
    public class PlayerWeaponRifle : PlayerWeapon
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform muzzleTransform;

        [FormerlySerializedAs("audioSource")] [SerializeField] private AudioSource audioPlayer;
        [SerializeField] private AudioClip fireSound;
        [SerializeField] private AudioClip reloadSound;
        
        // 탄피 제거 효과 파티클.
        //[SerializeField] private Transform cartridgeEjectTransform;
        [SerializeField] private ParticleSystem cartridgeEjectEffect;
        [SerializeField] private ParticleSystem muzzleFlashEffect;
        
        // 카메라 흔들기.
        [SerializeField] private CameraShake cameraShake;

        [SerializeField] private PlayerData data;
        [SerializeField] private int currentAmmo = 0;
        [SerializeField] private PlayerAnimationController animationController;

        [SerializeField] private float fireRate = 0.3f;
        private float nextFireTime = 0f;

        public UnityEvent OnReloadEvent;
        
        private bool CanFire
        {
            get { return currentAmmo > 0 && Time.time > nextFireTime; }
        }
        
        protected override void Awake()
        {
            base.Awake();
            currentAmmo = data.maxAmmo;
        }
        
        public override void Fire()
        {
            base.Fire();

            if (CanFire == false)
            {
                return;
            }
            
            --currentAmmo;
            
            // 다음에 발사가 가능한 시간 저장.
            nextFireTime = Time.time + fireRate;
            
            Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
            audioPlayer.PlayOneShot(fireSound);
            
            cartridgeEjectEffect.Play();
            muzzleFlashEffect.Play();
            
            cameraShake.Play();

            if (currentAmmo == 0)
            {
                //animationController.OnReload();
                OnReloadEvent?.Invoke();
                
                
                audioPlayer.PlayOneShot(reloadSound);
                Invoke("Reload", animationController.WaitTimeToReload());
                
            }
        }

        private void Reload()
        {
            currentAmmo = data.maxAmmo;
        }
    }
}