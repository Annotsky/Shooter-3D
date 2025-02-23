using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 100f;
    
    private const string PlayerString = "Player";

    private void Update()
    {
        transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerString))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickup(activeWeapon);
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickup(ActiveWeapon activeWeapon);
}