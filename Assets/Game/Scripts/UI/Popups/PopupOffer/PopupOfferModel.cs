using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

namespace Example.Scripts.UI.Popups.Offer
{
    [System.Serializable]
    internal struct ItemData
    {
        public string Name;
        public string Icon;
        public int    Count;
        
        public ItemData(string name, string icon, int count)
        {
            Name = name;
            Icon = icon;
            Count = count;
        }
    }

    [RequireComponent(typeof(PopupOfferView), typeof(PopupOfferController))]
    internal class PopupOfferModel : PopupModel
    {
        //----------<Fields>----------

        //MVC
        private PopupOfferView _popupView;

        //DATA
        private string          _offerTitle;
        private string          _offerDesc;
        private string          _offerPicture;
        private List<ItemData>  _offerItems;
        private float           _offerPrice;
        private float           _offerDiscount;

        //PROPERTIES
        public  string          Title    { get { return _offerTitle; } }
        public  string          Desc     { get { return _offerDesc; } }
        public  string          Picture  { get { return _offerPicture; } }
        public  List<ItemData> Items    { get { return _offerItems; } }
        public float            Price    { get { return _offerPrice; } }
        public float            Discount { get { return _offerDiscount; } }

        //----------<Unity>----------

        private void Awake()
        {
            //MVC
            _popupView = GetComponent<PopupOfferView>();
        }

        //----------<Model>----------

        public void SetTitle(string title)
        {
            _offerTitle = title;
            _popupView.UpdateTitle(title);
        }

        public void SetDesc(string desc)
        {
            _offerDesc = desc;
            _popupView.UpdateDesc(desc);
        }

        public void SetPicture(string picture)
        {
            _offerPicture = picture;
            _popupView.UpdatePicture(picture);
        }

        public void SetItems(List<ItemData> items)
        {
            _offerItems = items;
            _popupView.UpdateItems(items);
        }

        public void SetPrice(float price, float discount)
        {
            _offerPrice = price;
            _offerDiscount = discount;
            _popupView.UpdatePrice(price, discount);
        }
    }
}