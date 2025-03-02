using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    private FirstPersonController _player; 
    private NavMeshAgent _navMeshAgent;
    private EnemyHealth _enemyHealth;
    
    private const string PlayerString = "Player";

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        _player = FindFirstObjectByType<FirstPersonController>();
    }

    private void Update()
    {
        if (!_player) return;
        _navMeshAgent.SetDestination(_player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerString))
        {
            _enemyHealth.SelfDestruct();
        }
    }
}