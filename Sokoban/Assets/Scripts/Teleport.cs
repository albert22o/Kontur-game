using Assets.Scripts;
using UnityEngine;

public class Teleport : MonoBehaviour, IPlayerObstacle
{
    [SerializeField] 
    private Teleport connectedTeleport;

    public bool Interact(Vector3 direction, PlayerController playerController)
    {
        if (connectedTeleport == null)
        {
            Debug.LogError("Connected teleport is not assigned.");
            return false;
        }

        TeleportPlayer(playerController);
        return false;
    }

    private void TeleportPlayer(PlayerController player)
    {
        player.transform.position = connectedTeleport.transform.position;
    }
}