using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;

    protected virtual void Awake()
    {
    }

    public void LoadWeapon(Transform weaponHolder)
    {
        // WeaponHolder를 무기의 부모로 지정.
        transform.SetParent(weaponHolder);

        // 트랜스폼 초기화.
        transform.localPosition = Vector3.zero + positionOffset;
        transform.localRotation = Quaternion.identity * Quaternion.Euler(rotationOffset) ;
        //transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
    }

    public virtual void Fire()
    {
        
    }
}
