using System;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Students._NengkuanChen.Scripts
{
    public class FixedDealerHand : DealerHand
    {
        private void Awake()
        {
            EventUtility.Subscribe(typeof(OnStartButtonClickedEventArgs), OnStartButtonClicked);
            EventUtility.Subscribe(typeof(OnPlayerStayEventArgs), OnPlayerStay);
        }

        private void OnPlayerStay(object sender, GameEventArgs args)
        {
            RevealCard();
        }

        private void OnStartButtonClicked(object sender, GameEventArgs args)
        {
            SetupHand();
        }

        private void Start()
        {
            
        }

        
        
        
        protected override bool DealStay(int handVal)
        {
            return handVal >= 17;
        }

        protected override void ShowValue()
        {
            base.ShowValue();
            
        }
        
        private void OnDestroy()
        {
            EventUtility.Unsubscribe(typeof(OnStartButtonClickedEventArgs), OnStartButtonClicked);
            EventUtility.Unsubscribe(typeof(OnPlayerStayEventArgs), OnPlayerStay);
        }
    }
}