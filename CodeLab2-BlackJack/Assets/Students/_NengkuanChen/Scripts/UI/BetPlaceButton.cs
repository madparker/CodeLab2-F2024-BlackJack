using System;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Students._NengkuanChen.Scripts.UI
{
    public class BetPlaceButton : MonoBehaviour
    {
        [SerializeField]
        private int betAmount;
        
        public int BetAmount => betAmount;

        [SerializeField] 
        private Button button;
        
        private void Awake()
        {
            button.onClick.AddListener(() =>
            {
                EventUtility.TriggerNow(this,
                    new OnPlayerPlaceBetEventArgs(betAmount));
            });
            EventUtility.Subscribe(typeof(OnStartButtonClickedEventArgs), OnStartButtonClicked);
        }

        private void OnStartButtonClicked(object sender, GameEventArgs args)
        {
            gameObject.SetActive(false);
        }
        
        private void OnDestroy()
        {
            EventUtility.Unsubscribe(typeof(OnStartButtonClickedEventArgs), OnStartButtonClicked);
        }
    }
}