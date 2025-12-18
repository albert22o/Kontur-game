namespace Assets.Scripts.EnemyBehavior
{
    public class StateManager
    {
        private IState currentState;
        public void SetState(IState newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState.Enter();
        }

        public bool Update()
        {
            return currentState.Execute();
        }

        public IState GetState()
        {
            return currentState;
        }
    }
}
