using Assets.Scripts;
using UnityEngine;

public class Box : MoveableGridObject, IPlayerObstacle, IScoreModifier
{
    public bool Interact(Vector3 direction, PlayerController playerController)
    {
        return Move(direction);
    }

    public int ModifyScore(int oldScore)
    {
        return oldScore + 1;
    }

    public int RevertScore(int oldScore)
    {
        return oldScore - 1;
    }
}
