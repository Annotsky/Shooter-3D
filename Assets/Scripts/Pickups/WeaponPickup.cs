using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] private WeaponData weaponData;

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.SwitchWeapon(weaponData);
    }
}