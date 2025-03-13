using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private int _damage;

    private void Start()
    {
        Explode();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider hitCollider in hitColliders)
        {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();

            if (!playerHealth) continue;
            playerHealth.TakeDamage(_damage);
            break;
        }
    }
}