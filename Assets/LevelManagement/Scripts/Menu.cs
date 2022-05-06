using UnityEngine;

namespace LevelManagement
{
    [DisallowMultipleComponent]
    public abstract class Menu : MonoBehaviour
    {
        public void Init()
        {
        }

        public virtual void OnBackButtonClick()
        {
            MenuManager.Instance.CloseMenu();
        }
    }
}