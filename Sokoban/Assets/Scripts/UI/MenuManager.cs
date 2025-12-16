using UnityEngine;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Класс для управлением меню
    /// </summary>
    class MenuManager : MonoBehaviour
    {
        private void Start()
        {
            foreach (var section in GetComponentsInChildren<MenuSection>(true))
                section.OnShowElement += HandleShowElement;
        }

        private void HandleShowElement(GameObject gameObject)
        {
            foreach (var section in GetComponentsInChildren<MenuSection>(true))
                section.gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}
