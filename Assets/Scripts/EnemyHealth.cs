using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject _robotExplosion;
    [SerializeField] private int _startingHealth;

    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _startingHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            Instantiate(_robotExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}