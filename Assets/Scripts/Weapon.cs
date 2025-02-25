using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shootParticle;
    [SerializeField] private LayerMask _interactionLayers;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void Shoot(WeaponSO _weaponSo)
    {
        _shootParticle.Play();

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out var hit,
                Mathf.Infinity, _interactionLayers, QueryTriggerInteraction.Ignore))
        {
            Instantiate(_weaponSo.HitParticles, hit.point, Quaternion.identity);
            EnemyHealth _enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            _enemyHealth?.TakeDamage(_weaponSo.Damage);
        }
    }
}