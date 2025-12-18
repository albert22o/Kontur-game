namespace Assets.Scripts.EnemyBehavior
{
    public interface IState
    {
        public void Enter();
        /// <summary>
        /// Выполнение логики состояния
        /// </summary>
        /// <returns>Может ли он выполнить логику</returns>
        public bool Execute();
        public void Exit();
    }
}
