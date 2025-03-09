using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed = 30f;

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
        
        Destroy(gameObject);
    }
}
