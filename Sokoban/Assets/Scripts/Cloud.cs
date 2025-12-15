using Assets.Scripts;
using System;
using UnityEngine;

class Cloud : MonoBehaviour, IPlayerObstacle
{
    public event Action OnObjectDestroy;
    public bool Interact(Vector3 direction, PlayerController playerController)
    {
        DestroyCloud();
        return true;
    }

    private void DestroyCloud()
    {
        OnObjectDestroy?.Invoke();
        Destroy(gameObject);
    }
}
