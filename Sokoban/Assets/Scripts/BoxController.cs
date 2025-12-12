using Assets.Scripts;
using System;
using System.Collections;
using UnityEngine;

public class BoxController : MoveableGridObject, IObstacle
{
    public bool Interact(Vector3 direction)
    {
        return Move(direction);
    }
}
