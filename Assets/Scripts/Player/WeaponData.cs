using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponData : ScriptableObject
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private GameObject _hitParticles;
    
    [Header("Stats")]
    [SerializeField] private int _damage;
    [SerializeField] private float _fireRate;
    [SerializeField] private int _magazineSize;
    [SerializeField] private bool _isAutomatic;
    
    [Header("Zoom")]
    [SerializeField] private bool _canZoom;
    [SerializeField] private float _zoomAmount;
    [SerializeField] private float _zoomRotationSpeed;
    
    public GameObject WeaponPrefab => _weaponPrefab;
    public GameObject HitParticles => _hitParticles;
    public int Damage => _damage;
    public float FireRate => _fireRate;
    public bool IsAutomatic => _isAutomatic;
    public int MagazineSize => _magazineSize;
    public bool CanZoom => _canZoom;
    public float ZoomAmount => _zoomAmount;
    public float ZoomRotationSpeed => _zoomRotationSpeed;
}