using System;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Students._NengkuanChen.Scripts.UI
{
    public class StayButton : MonoBehaviour
    {
        
        [SerializeField]
        private Button stayButton;
        
        
        private void Awake()
        {
            EventUtility.Subscribe(typeof(OnStartButtonClickedEventArgs), OnStartButtonClicked);
            stayButton.onClick.AddListener(() =>
            {
                EventUtility.TriggerNow(this, new OnPlayerStayEventArgs());
            });
            gameObject.SetActive(false);
        }

        private void OnStartButtonClicked(object sender, GameEventArgs args)
        {
            gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            EventUtility.Unsubscribe(typeof(OnStartButtonClickedEventArgs), OnStartButtonClicked);
        }
    }
}