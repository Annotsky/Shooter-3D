using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private StarterAssetsInputs _starterAssetsInputs;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (!_starterAssetsInputs.shoot) return;
        bool isRaycast = Physics.Raycast(_camera.transform.position, _camera.transform.forward, 
                                               out var hit, Mathf.Infinity);

        if (!isRaycast) return;
        Debug.Log(hit.collider.name);
        _starterAssetsInputs.ShootInput(false);
    }
}