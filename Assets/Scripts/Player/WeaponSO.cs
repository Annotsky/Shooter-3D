using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private GameObject _hitParticles;
    [Header("Stats")]
    [SerializeField] private int _damage = 20;
    [SerializeField] private float _fireRate = .5f;
    [SerializeField] private int _magazineSize = 12;
    [SerializeField] private bool _isAutomatic;
    [Header("Zoom")]
    [SerializeField] private bool _canZoom;
    [SerializeField] private float _zoomAmount = 30f;
    [SerializeField] private float _zoomRotationSpeed = 0.3f;
    
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