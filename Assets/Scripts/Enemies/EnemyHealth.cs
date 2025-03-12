using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject _robotExplosion;
    [SerializeField] private int _startingHealth;

    private int _currentHealth;

    private EnemyCounter _enemyCounter;
    
    private void Awake()
    {
        _currentHealth = _startingHealth;
    }

    private void Start()
    {
        CountEnemies();
    }

    private void CountEnemies()
    {
        _enemyCounter = FindFirstObjectByType<EnemyCounter>();
        _enemyCounter.AdjustEnemiesLeft(1);
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            _enemyCounter.AdjustEnemiesLeft(-1);
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        Instantiate(_robotExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}