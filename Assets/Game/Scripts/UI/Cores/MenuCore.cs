using UnityEngine;
using UnityEngine.UI;

using Example.Scripts.ScriptableObjects;
using Example.Scripts.UI.Popups;
using Example.Scripts.UI.Popups.Offer;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;
using Example.Scripts.Systems;

namespace Example.Scripts.UI.Cores
{
    internal class MenuCore : MonoBehaviour
    {
        //>>> TODO: Probably need to apply MVC pattern to menu logic, but it is not important since it is just simple example

        //----------<Fields>----------

        [Header("UI")]
        [SerializeField] private Canvas     _uiCanvas;        
        [SerializeField] private Button     _buttonOffer;

        [Header("POPUPS")]
        [SerializeField] private PopupsData _popupsData;

        [Header("EXAMPLE")]
        [SerializeField]                  private string         _exampleOfferTitle;
        [SerializeField]                  private string         _exampleOfferDesc;
        [SerializeField]                  private string         _exampleOfferPicture;
        [SerializeField]                  private List<ItemData> _exampleOfferItems;
        [SerializeField][Range(0f, 100f)] private float          _exampleOfferPrice;
        [SerializeField][Range(0f, 1f)]   private float          _exampleOfferDiscount;

        //----------<Unity>----------

        public void Awake()
        {
            //MUSIC
            MusicSystem.Instance.PlayMusic("IntroTheme");

            //EVENTS
            _buttonOffer.onClick.AddListener(ButtonOffer_OnClick);
        }

        public void OnDestroy()
        {
            _buttonOffer.onClick.RemoveAllListeners();
        }

        //----------<Popups>----------

        public void ButtonOffer_OnClick()
        {
            //Sound
            SoundSystem.Instance.PlaySound("BigButtonClick");

            //Logic
            try
            {
                CreateOfferPopup(_exampleOfferTitle, _exampleOfferDesc, _exampleOfferPicture, _exampleOfferItems, _exampleOfferPrice, _exampleOfferDiscount);
            }            
            catch(NullReferenceException)
            {
                Debug.LogError($"MenuCore.ButtonOffer_OnClick(): Null data.");
            }
        }

        //----------<>----------

        private void CreateOfferPopup(string title, string desc, string picture, List<ItemData> items, float price, float discount)
        {
            PopupOfferController controller = (PopupOfferController)CreatePopup("popup_offer");

            if (!controller) { return; }

            controller.Init(title, desc, picture, items, price, discount);
        }

        private PopupController CreatePopup(string name)
        {
            var data = _popupsData.Find(name);
            if(data.Equals(default(PopupData))) { return null; }

            var popup = Instantiate(data.Prefab, _uiCanvas.transform);
            return popup.GetComponent<PopupController>();
        }
    }
}