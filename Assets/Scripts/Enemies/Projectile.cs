using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private GameObject _projectileHitEffect;

    private Rigidbody _projectileRigidbody;
    private int _damage;

    private void Awake()
    {
        _projectileRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _projectileRigidbody.linearVelocity = transform.forward * _projectileSpeed;
    }

    public void Init(int damage)
    {
        _damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(_damage);

        Instantiate(_projectileHitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}