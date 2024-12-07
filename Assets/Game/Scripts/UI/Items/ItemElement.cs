using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace Example.Scripts.UI.Elements
{
    public class ItemElement : MonoBehaviour
    {
        //UI
        [Tooltip("UI")]
        [SerializeField] private Image    _itemIconImage;
        [SerializeField] private TMP_Text _itemCountText;

        //PROPERTIES
        public Sprite Icon  { set { _itemIconImage.sprite = value; } }
        public int    Count { set { _itemCountText.text = value.ToString(); } }
    }
}