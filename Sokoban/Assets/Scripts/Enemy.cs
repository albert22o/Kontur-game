
using Assets.Scripts.EnemyBehavior;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    class Enemy : MoveableGridObject, IPlayerObstacle
    {
        [SerializeField] private bool horizontalMovement = false;
        private StateManager stateManager;
        private PatrolState moveForward;
        private PatrolState moveBackward;
        public bool Interact(Vector3 direction, PlayerController playerController)
        {
            playerController.Death();
            return true;
        }
        public override bool Move(Vector3 direction)
        {
            transform.rotation = Quaternion.LookRotation(direction);
            return base.Move(direction);
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
            if (horizontalMovement) 
            {
                moveForward = new PatrolState(this, Vector3.left);
                moveBackward = new PatrolState(this, -Vector3.left);
            }
            else
            {
                moveForward = new PatrolState(this, Vector3.forward);
                moveBackward = new PatrolState(this, Vector3.back);
            }
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
                    if (directionVector == Vector3.forward
                        || directionVector == Vector3.left)
                        stateManager.SetState(moveBackward);
                    else
                        stateManager.SetState(moveForward);
                }
                yield return new WaitForSeconds(0.5f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IMortal obstacle))
            {
                obstacle.Death();
            }
        }
    }
}
