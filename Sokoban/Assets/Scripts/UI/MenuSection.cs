using System;
using UnityEngine;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Класс для основных разделов меню
    /// </summary>
    class MenuSection : MonoBehaviour
    {
        public Action<GameObject> OnShowElement;
        /// <summary>
        /// Метод для отображения текущего раздела меню
        /// </summary>
        public void ShowElement()
        {
            OnShowElement?.Invoke(gameObject);
        }
    } 
}
