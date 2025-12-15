using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IPlayerObstacle
    {
        /// <summary>
        /// Метод взаимодействия игрока с препятствием
        /// </summary>
        /// <param name="direction">Направление в котором движется игрок</param>
        /// <param name="playerController"> Контроллер игрока, взаимодействующего с препятствием</param>
        /// <returns>может ли игрок после этого пройти</returns>
        public bool Interact(Vector3 direction, PlayerController playerController);
    }
}