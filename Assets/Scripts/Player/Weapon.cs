using Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shootParticle;
    [SerializeField] private LayerMask _interactionLayers;

    private CinemachineImpulseSource _impulseSource;
    private Camera _camera;

    private void Awake()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
        _camera = Camera.main;
    }

    public void Shoot(WeaponData weaponData)
    {
        _shootParticle.Play();
        _impulseSource.GenerateImpulse();

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out var hit,
                Mathf.Infinity, _interactionLayers, QueryTriggerInteraction.Ignore))
        {
            Instantiate(weaponData.HitParticles, hit.point, Quaternion.identity);
            EnemyHealth _enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            _enemyHealth?.TakeDamage(weaponData.Damage);
        }
    }
}