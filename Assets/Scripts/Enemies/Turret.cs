using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _turretHead;
    [SerializeField] private Transform _playerTargetPoint;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private float _fireRate;
    [SerializeField] private int _damage;

    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(Fire());
    }

    private void Update()
    {
        transform.LookAt(_playerTargetPoint);
    }

    private IEnumerator Fire()
    {
        while (_playerHealth)
        {
            yield return new WaitForSeconds(_fireRate);
            Projectile newProjectile = Instantiate(_projectilePrefab,
                    _projectileSpawnPoint.position, Quaternion.identity)
                .GetComponent<Projectile>();
            newProjectile.transform.LookAt(_playerTargetPoint);
            newProjectile.Init(_damage);
        }
    }
}