using UnityEngine;

using Example.Scripts.UI.Patterns;

namespace Example.Scripts.UI.Popups
{
    internal abstract class PopupController : MonoBehaviour, IController
    {
        public virtual void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
