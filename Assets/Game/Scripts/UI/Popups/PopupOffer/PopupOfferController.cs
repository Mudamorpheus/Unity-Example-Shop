using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace Example.Scripts.UI.Popups.Offer
{
    [RequireComponent(typeof(PopupOfferModel), typeof(PopupOfferView))]
    internal class PopupOfferController : PopupController
    {
        //----------<Fields>----------

        //BUTTONS
        [Header("EVENTS")]
        [SerializeField] private Button _popupBuyButton;

        //MVC
        private PopupOfferModel _popupModel;

        //----------<Unity>----------

        private void Awake()
        {
            //MVC
            _popupModel = GetComponent<PopupOfferModel>();

            //Events
            _popupBuyButton.onClick.AddListener(Destroy);
        }

        private void OnDestroy()
        {
            _popupBuyButton.onClick.RemoveAllListeners();
        }

        //----------<Controller>----------

        public void Init(string title, string desc, string picture, List<ItemData> items, float price, float discount)
        {
            _popupModel.SetTitle(title);
            _popupModel.SetDesc(desc);
            _popupModel.SetPicture(picture);            
            _popupModel.SetItems(items);
            _popupModel.SetPrice(price, discount);            
        }
    }
}
