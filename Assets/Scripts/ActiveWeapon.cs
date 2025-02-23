using Cinemachine;
using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private WeaponSO _weaponSo;
    [SerializeField] private CinemachineVirtualCamera _playerFollowCamera;

    [SerializeField] private GameObject _zoomVignette;

    private FirstPersonController _firstPersonController;
    private Animator _animator;
    private StarterAssetsInputs _starterAssetsInputs;
    private Weapon _currentWeapon;

    private float _timeSinceLastShot;
    private float _defaultFOV;
    private float _defaultRotationSpeed;

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
        _currentWeapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    public void SwitchWeapon(WeaponSO weaponSo)
    {
        if (_currentWeapon)
        {
            Destroy(_currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSo.weaponPrefab, transform).GetComponent<Weapon>();
        _currentWeapon = newWeapon;
        _weaponSo = weaponSo;
    }

    private void HandleShoot()
    {
        _timeSinceLastShot += Time.deltaTime;

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

    private void HandleZoom()
    {
        if (!_weaponSo.CanZoom) return;

        if (_starterAssetsInputs.zoom)
        {
            SetZoomState(_weaponSo.ZoomAmount, true, _weaponSo.ZoomRotationSpeed);
        }
        else
        {
            SetZoomState(_defaultFOV, false, _defaultRotationSpeed);
        }
    }

    private void SetZoomState(float fov, bool isVignetteActive, float rotationSpeed)
    {
        _playerFollowCamera.m_Lens.FieldOfView = fov;
        _zoomVignette.SetActive(isVignetteActive);
        _firstPersonController.ChangeRotationSpeed(rotationSpeed);
    }
}