using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponPrefab;
    public int Damage = 20;
    public float FireRate = .5f;
    public GameObject HitParticles;
    public bool IsAutomatic = false;
    public bool CanZoom = false;
    public float ZoomAmount = 30f;
    public float ZoomRotationSpeed = 0.3f;
    public int MagazineSize = 12;
}