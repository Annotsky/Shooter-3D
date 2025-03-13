using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] private GameObject _robotPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _robotSpawnDelay;

    private PlayerHealth _player;

    private void Start()
    {
        _player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (_player)
        {
            Instantiate(_robotPrefab, _spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(_robotSpawnDelay);
        }
    }
}