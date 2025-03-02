using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] private int _ammoAmount;
    
    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.AdjustAmmo(_ammoAmount);
    }
}