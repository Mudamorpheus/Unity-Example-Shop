using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

using Example.Scripts.ScriptableObjects;
using Example.Scripts.UI.Elements;
using DG.Tweening;
using Example.Scripts.Systems;

namespace Example.Scripts.UI.Popups.Offer
{
    [RequireComponent(typeof(PopupOfferModel), typeof(PopupOfferController))]
    internal class PopupOfferView : PopupView
    {
        //----------<Fields>----------

        //UI
        [Header("UI")]
        [SerializeField] private TMP_Text         _popupTitleLabel;
        [SerializeField] private TMP_Text         _popupDescLabel;
        [SerializeField] private Image            _popupPictureImage;
        [SerializeField] private GridLayoutGroup  _popupItemsGridGroup;
        [SerializeField] private TMP_Text         _popupNewPriceText;
        [SerializeField] private TMP_Text         _popupOldPriceText;
        [SerializeField] private TMP_Text         _popupDiscountText;

        //PREFABS
        [Header("PREFABS")]
        [SerializeField] private ItemElement _popupItemElementPrefab;

        //ICONS
        [Header("ICONS")]
        [SerializeField] private IconsData _itemIconsData;
        [SerializeField] private IconsData _pictureIconsData;

        //----------<Unity>----------

        private void OnDestroy()
        {
            //>>> TODO: Move sound to another place.
            SoundSystem.Instance.PlaySound("GoodJob");
        }

        //----------<View>----------

        public void UpdateTitle(string title)
        {
            _popupTitleLabel.text = title;
        }

        public void UpdateDesc(string desc)
        {
            _popupDescLabel.text = desc;
        }

        public void UpdateItems(List<ItemData> items)
        {
            foreach(var item in items)
            {
                var element = Instantiate(_popupItemElementPrefab, _popupItemsGridGroup.transform);
                element.Icon  = _itemIconsData.FindSprite(item.Icon);
                element.Count = item.Count;
            }
        }

        public void UpdatePicture(string picture)
        {
            var sprite = _pictureIconsData.FindSprite(picture);

            if(sprite == null) { return; }

            _popupPictureImage.sprite = sprite;
        }

        public void UpdatePrice(float price, float discount)
        {
            _popupOldPriceText.text = price.ToString("<s>$0.00</s>");
            _popupNewPriceText.text = (price-price*discount).ToString("$0.00");
            _popupDiscountText.text = discount.ToString("0%");
        }        
    }
}