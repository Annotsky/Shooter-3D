using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private WeaponSO _weaponSo;
    
    private Animator _animator;
    private StarterAssetsInputs _starterAssetsInputs;
    private Weapon _currentWeapon;

    private float _timeSinceLastShot;
    private const string ShootString = "Shoot";
    
    private void Awake()
    {
        _starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _currentWeapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (!_starterAssetsInputs.shoot) return;

        if (_timeSinceLastShot >= _weaponSo.FireRate)
        {
            _currentWeapon.Shoot(_weaponSo);
            _animator.Play(ShootString, 0, 0f);
            _timeSinceLastShot = 0f;
        }

        if (!_weaponSo.IsAutomatic)
        {
            _starterAssetsInputs.ShootInput(false);
        }
    }
}
