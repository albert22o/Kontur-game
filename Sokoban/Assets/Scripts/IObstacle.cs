using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IObstacle
    {
        /// <summary>
        /// Метод взаимодействия игрока с препятствием
        /// </summary>
        /// <param name="direction">Направление в котором движется игрок</param>
        /// <returns>может ли игрок после этого пройти</returns>
        public bool Interact(Vector3 direction);
    }
}