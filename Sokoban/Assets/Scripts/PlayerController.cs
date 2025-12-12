using Assets.Scripts;
using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MoveableGridObject
{
    void Update()
    {
        if (IsMoving)
            return;

        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
            direction = Vector3.left;
        if (Input.GetKey(KeyCode.RightArrow))
            direction = Vector3.right;
        if (Input.GetKey(KeyCode.UpArrow))
            direction = Vector3.forward;
        if (Input.GetKey(KeyCode.DownArrow))
            direction = Vector3.back;

        if (direction != Vector3.zero)
            Move(direction);
    }

    protected override bool HandleCollision(RaycastHit hit, Vector3 direction)
    {
        if (hit.collider.TryGetComponent(out IObstacle box))
            return box.Interact(direction);

        return false; 
    }
}