using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //переделать HandleShoot под эвент
    [SerializeField] private Animator _animator;
    [SerializeField] private int _damageAmount;
    [SerializeField] private ParticleSystem _shootParticle;
    [SerializeField] private GameObject _hitParticles;
    
    private StarterAssetsInputs _starterAssetsInputs;
    private Camera _camera;

    private const string ShootString = "Shoot";
    
    private void Awake()
    {
        _camera = Camera.main;
        _starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    private void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (!_starterAssetsInputs.shoot) return;
        _starterAssetsInputs.ShootInput(false);
        
        _shootParticle.Play();
        _animator.Play(ShootString, 0, 0f);

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward,
                out var hit, Mathf.Infinity))
        {
            Instantiate(_hitParticles, hit.point, Quaternion.identity);

            EnemyHealth _enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            _enemyHealth?.TakeDamage(_damageAmount);
        }
    }
}