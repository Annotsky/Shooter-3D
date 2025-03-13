using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private const string EnemiesLeftString = "Enemies Left: ";

    [SerializeField] private TMP_Text _enemiesLeftText;
    [SerializeField] private GameObject _youWinText;

    private int _enemiesLeft;

    public void AdjustEnemiesLeft(int amount)
    {
        _enemiesLeft += amount;
        _enemiesLeftText.text = EnemiesLeftString + _enemiesLeft;

        if (_enemiesLeft <= 0)
        {
            _youWinText.SetActive(true);
        }
    }
}