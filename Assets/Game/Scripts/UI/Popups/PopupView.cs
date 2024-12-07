using UnityEngine;

using Example.Scripts.UI.Patterns;

namespace Example.Scripts.UI.Popups
{
    internal abstract class PopupView : MonoBehaviour, IView
    {
        public virtual void Show() 
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
