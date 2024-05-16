using System;
using FPSGame;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private PlayerWeapon weapon;

    private void Awake()
    {
        weapon.LoadWeapon(weaponHolder);
    }

    private void Update()
    {
        if (PlayerInputManager.IsFire)
        {
            weapon.Fire();
        }
    }
}
