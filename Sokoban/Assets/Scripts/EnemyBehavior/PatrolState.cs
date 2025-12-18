using System;
using UnityEngine;

namespace Assets.Scripts.EnemyBehavior
{
    public class PatrolState : IState
    {
        public Vector3 DirectionToMove => directionToMove;
        private readonly MoveableGridObject moveableGridObject;
        private readonly Vector3 directionToMove;
        public PatrolState(MoveableGridObject moveableGridObject, Vector3 directionToMove) 
        {
            this.moveableGridObject = moveableGridObject;
            this.directionToMove = directionToMove;
        }
        public void Enter()
        {

        }

        public bool Execute()
        {
            return moveableGridObject.Move(directionToMove);
        }

        public void Exit()
        {

        }
    }
}
