using System;
using UnityEngine;
using Utility;

namespace Students._NengkuanChen.Scripts
{
    public class FixedBlackJackHand : BlackJackHand
    {
        private void Awake()
        {
            EventUtility.Subscribe(typeof(OnStartButtonClickedEventArgs), OnStartButtonClicked);
            EventUtility.Subscribe(typeof(OnPlayerHitEventArgs), OnPlayerHit);
        }

        private void OnPlayerHit(object sender, GameEventArgs args)
        {
            if(args is OnPlayerHitEventArgs hitArgs)
            {
                HitMe();
                if (hitArgs.IsDoubleDown)
                {
                    BankrollManager.DoubleDown();
                    if (GetHandValue() <= 21)
                    {
                        EventUtility.TriggerNow(this, new OnPlayerStayEventArgs());

                    }
                }
                
            }
            
        }

        private void OnStartButtonClicked(object sender, GameEventArgs args)
        {
            SetupHand();
        }

        void Start()
        {
            
        }
        
        protected override void SetupHand()
        {
            base.SetupHand();
            
        }

        protected override void ShowValue()
        {
            base.ShowValue();
            if (GetType() != typeof(FixedDealerHand))
            {
                if (GetHandValue() == 21)
                {
                    GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().PlayerWin();
                }
            }
        }

        private void OnDestroy()
        {
            EventUtility.Unsubscribe(typeof(OnStartButtonClickedEventArgs), OnStartButtonClicked);
            EventUtility.Unsubscribe(typeof(OnPlayerHitEventArgs), OnPlayerHit);
        }
    }
}