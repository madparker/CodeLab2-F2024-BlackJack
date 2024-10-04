using System;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Students._NengkuanChen.Scripts.UI
{
    public class ClearBetButton : MonoBehaviour
    {
        [SerializeField]
        private Button clearBetButton;
        
        private void Awake()
        {
            clearBetButton.onClick.AddListener(() =>
            {
                EventUtility.TriggerNow(this, new OnPlayerPlaceBetEventArgs(-Int32.MaxValue));
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