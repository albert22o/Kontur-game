using Assets.Scripts;
using System;
using UnityEngine;

class Ice : MonoBehaviour, IPlayerObstacle
{
    public event Action OnObjectDestroy;
    public bool Interact(Vector3 direction, PlayerController playerController)
    {
        DestroyObject();
        return true;
    }

    private void DestroyObject()
    {
        OnObjectDestroy?.Invoke();
        Destroy(gameObject);
    }
}
