
using Assets.Scripts.EnemyBehavior;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    class Enemy : MoveableGridObject, IPlayerObstacle
    {
        private StateManager stateManager;
        private PatrolState moveForward;
        private PatrolState moveBackward;
        public bool Interact(Vector3 direction, PlayerController playerController)
        {
            playerController.Death();
            return true;
        }

        protected override bool HandleCollision(RaycastHit hit, Vector3 direction)
        {
            if (hit.collider.TryGetComponent(out IMortal obstacle))
            {
                obstacle.Death();
                return true;
            }
            return false;
        } 
        
        private void Start()
        {
            stateManager = new StateManager();
            moveForward = new PatrolState(this, Vector3.forward);
            moveBackward = new PatrolState(this, Vector3.back);
            stateManager.SetState(moveForward);
            StartCoroutine(UpdateStates());
        }

        private IEnumerator UpdateStates()
        {
            while (true)
            {
                var directionVector = ((PatrolState)stateManager.GetState()).DirectionToMove;
                if (!stateManager.Update())
                {
                    if (directionVector == Vector3.forward)
                        stateManager.SetState(moveBackward);
                    else
                        stateManager.SetState(moveForward);
                }
                yield return new WaitForSeconds(0.5f);
            }
        }

        public override bool Move(Vector3 direction)
        {
            transform.rotation = Quaternion.LookRotation(direction);
            return base.Move(direction);
        }   
    }
}
