using UnityEngine;
using UnityEngine.Serialization;

public class WeaponPickup : Pickup
{
    [FormerlySerializedAs("_weaponSo")] [SerializeField] private WeaponData weaponData;

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.SwitchWeapon(weaponData);
    }
}