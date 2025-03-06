using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private WeaponSO _startingWeaponSo;
    [SerializeField] private CinemachineVirtualCamera _playerFollowCamera;
    [SerializeField] private Camera _weaponCamera;
    [SerializeField] private GameObject _zoomVignette;
    [SerializeField] private TMP_Text _ammoText;

    private WeaponSO _currentWeaponSo;
    private FirstPersonController _firstPersonController;
    private Animator _animator;
    private StarterAssetsInputs _starterAssetsInputs;
    private Weapon _currentWeapon;

    private float _timeSinceLastShot;
    private float _defaultFOV;
    private float _defaultRotationSpeed;
    private int _currentAmmo;

    private const string ShootString = "Shoot";

    private void Awake()
    {
        _firstPersonController = GetComponentInParent<FirstPersonController>();
        _starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();
        _defaultFOV = _playerFollowCamera.m_Lens.FieldOfView;
        _defaultRotationSpeed = _firstPersonController.RotationSpeed;
    }

    private void Start()
    {
        SwitchWeapon(_startingWeaponSo);
        AdjustAmmo(_currentWeaponSo.MagazineSize);
    }

    private void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    public void AdjustAmmo(int amount)
    {
        _currentAmmo += amount;

        if (_currentAmmo > _currentWeaponSo.MagazineSize)
        {
            _currentAmmo = _currentWeaponSo.MagazineSize;
        }

        _ammoText.text = _currentAmmo.ToString("D2");
    }

    public void SwitchWeapon(WeaponSO weaponSo)
    {
        if (_currentWeapon)
        {
            Destroy(_currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSo.WeaponPrefab, transform).GetComponent<Weapon>();
        _currentWeapon = newWeapon;
        _currentWeaponSo = weaponSo;
        AdjustAmmo(_currentWeaponSo.MagazineSize);
    }

    private void HandleShoot()
    {
        _timeSinceLastShot += Time.deltaTime;

        if (!_starterAssetsInputs.shoot) return;

        if (_timeSinceLastShot >= _currentWeaponSo.FireRate && _currentAmmo > 0)
        {
            _currentWeapon.Shoot(_currentWeaponSo);
            _animator.Play(ShootString, 0, 0f);
            _timeSinceLastShot = 0f;
            AdjustAmmo(-1);
        }

        if (!_currentWeaponSo.IsAutomatic)
        {
            _starterAssetsInputs.ShootInput(false);
        }
    }

    private void HandleZoom()
    {
        if (!_currentWeaponSo.CanZoom) return;

        if (_starterAssetsInputs.zoom)
        {
            SetZoomState(_currentWeaponSo.ZoomAmount, true, _currentWeaponSo.ZoomRotationSpeed);
        }
        else
        {
            SetZoomState(_defaultFOV, false, _defaultRotationSpeed);
        }
    }

    private void SetZoomState(float fov, bool isVignetteActive, float rotationSpeed)
    {
        _playerFollowCamera.m_Lens.FieldOfView = fov;
        _weaponCamera.fieldOfView = fov;
        _zoomVignette.SetActive(isVignetteActive);
        _firstPersonController.ChangeRotationSpeed(rotationSpeed);
    }
}