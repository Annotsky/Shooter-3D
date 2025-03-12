using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _enemiesLeftText;
    [SerializeField] private GameObject _youWinText;

    private int _enemiesLeft;

    private const string EnemiesLeftString = "Enemies Left: ";
    
    public void AdjustEnemiesLeft(int amount)
    {
        _enemiesLeft += amount;
        _enemiesLeftText.text = EnemiesLeftString + _enemiesLeft;

        if (_enemiesLeft <=0 )
        {
            _youWinText.SetActive(true);
        }
    }
}
