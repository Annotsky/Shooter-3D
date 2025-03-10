using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Range(1, 10)] [SerializeField] private int _startingHealth;
    [SerializeField] private CinemachineVirtualCamera _deathVirtualCamera;
    [SerializeField] private Transform _weaponCamera;
    [SerializeField] private Image[] _shieldBars;
    [SerializeField] private GameObject _gameOverContainer;

    private int _gameOverVirtualCameraPriority = 20;
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _startingHealth;
        AdjustShieldUI();
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        AdjustShieldUI();

        if (_currentHealth <= 0)
        {
            PlayerGameOver();
        }
    }

    private void PlayerGameOver()
    {
        _weaponCamera.parent = null;
        _deathVirtualCamera.Priority = _gameOverVirtualCameraPriority;
        _gameOverContainer.SetActive(true);
        Destroy(gameObject);
    }

    private void AdjustShieldUI()
    {
        for (int i = 0; i < _shieldBars.Length; i++)
        {
            _shieldBars[i].gameObject.SetActive(i < _currentHealth);
        }
    }
}