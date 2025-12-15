using Assets.Scripts;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MoveableGridObject
{
    public void OnMove(InputValue value)
    {
        if (IsMoving)
            return;

        var inputDirection = value.Get<Vector2>();

        if (inputDirection == Vector2.zero)
            return;

        Vector3 direction;

        if (Mathf.Abs(inputDirection.x) > Mathf.Abs(inputDirection.y))
            direction = inputDirection.x > 0 ? Vector3.right : Vector3.left;
        else
            direction = inputDirection.y > 0 ? Vector3.forward : Vector3.back;

         Move(direction);
    }


    protected override bool HandleCollision(RaycastHit hit, Vector3 direction)
    {
        if (hit.collider.TryGetComponent(out IPlayerObstacle box))
            return box.Interact(direction, this);

        return false;
    }
}