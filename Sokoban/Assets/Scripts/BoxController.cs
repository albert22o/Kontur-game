using Assets.Scripts;
using System;
using System.Collections;
using UnityEngine;

public class BoxController : MoveableGridObject, IObstacle, IScoreModifier
{
    public bool Interact(Vector3 direction)
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
