using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private WeaponData _startingWeaponData;
    [SerializeField] private CinemachineVirtualCamera _playerFollowCamera;
    [SerializeField] private Camera _weaponCamera;
    [SerializeField] private GameObject _zoomVignette;
    [SerializeField] private TMP_Text _ammoText;

    private WeaponData _currentWeaponData;
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
        SwitchWeapon(_startingWeaponData);
        AdjustAmmo(_currentWeaponData.MagazineSize);
    }

    private void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    public void AdjustAmmo(int amount)
    {
        _currentAmmo += amount;

        if (_currentAmmo > _currentWeaponData.MagazineSize)
        {
            _currentAmmo = _currentWeaponData.MagazineSize;
        }

        _ammoText.text = _currentAmmo.ToString("D2");
    }

    public void SwitchWeapon(WeaponData weaponData)
    {
        if (_currentWeapon)
        {
            Destroy(_currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponData.WeaponPrefab, transform).GetComponent<Weapon>();
        _currentWeapon = newWeapon;
        _currentWeaponData = weaponData;
        AdjustAmmo(_currentWeaponData.MagazineSize);
    }

    private void HandleShoot()
    {
        _timeSinceLastShot += Time.deltaTime;

        if (!_starterAssetsInputs.shoot) return;

        if (_timeSinceLastShot >= _currentWeaponData.FireRate && _currentAmmo > 0)
        {
            _currentWeapon.Shoot(_currentWeaponData);
            _animator.Play(ShootString, 0, 0f);
            _timeSinceLastShot = 0f;
            AdjustAmmo(-1);
        }

        if (!_currentWeaponData.IsAutomatic)
        {
            _starterAssetsInputs.ShootInput(false);
        }
    }

    private void HandleZoom()
    {
        if (!_currentWeaponData.CanZoom) return;

        if (_starterAssetsInputs.zoom)
        {
            SetZoomState(_currentWeaponData.ZoomAmount, true, _currentWeaponData.ZoomRotationSpeed);
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