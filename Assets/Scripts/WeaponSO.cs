using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public int Damage = 20;
    public float FireRate = .5f;
    public GameObject HitParticles;
    public bool IsAutomatic = false;
}
