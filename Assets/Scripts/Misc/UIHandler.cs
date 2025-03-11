using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _enemiesLeftText;
    [SerializeField] private GameObject _youWinText;

    private int _enemiesLeft = 0;

    private const string EnemiesLeftString = "Enemies Left: ";
    
    public void AdjustEnemiesLeft(int amount)
    {
        _enemiesLeft += amount;
        _enemiesLeftText.text = EnemiesLeftString + _enemiesLeft.ToString();

        if (_enemiesLeft <=0 )
        {
            _youWinText.SetActive(true);
        }
    }
    
    public void RestartLevelButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
