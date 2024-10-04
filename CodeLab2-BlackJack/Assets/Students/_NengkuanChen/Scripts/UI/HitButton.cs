using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utility;

namespace Students._NengkuanChen.Scripts.UI
{
    public class HitButton : MonoBehaviour
    {
        [SerializeField]
        private Button hitButton;
        
        [SerializeField]
        private bool isDoubleDown = false;
        
        private void Awake()
        {
            hitButton.onClick.AddListener(() =>
            {
                EventUtility.TriggerNow(this, new OnPlayerHitEventArgs(isDoubleDown));
            });
            EventUtility.Subscribe(typeof(OnStartButtonClickedEventArgs), OnStartButtonClicked);
            EventUtility.Subscribe(typeof(OnPlayerHitEventArgs), OnPlayerHit);
            EventUtility.Subscribe(typeof(OnPlayerStayEventArgs), OnPlayerStay);
            EventUtility.Subscribe(typeof(OnGameEndEventArgs), OnGameEnd);
            gameObject.SetActive(false);
        }

        private void OnGameEnd(object sender, GameEventArgs args)
        {
            gameObject.SetActive(false);
        }

        private void OnPlayerStay(object sender, GameEventArgs args)
        {
            gameObject.SetActive(false);
        }

        private void OnPlayerHit(object sender, GameEventArgs args)
        {
            if (isDoubleDown)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnStartButtonClicked(object sender, GameEventArgs args)
        {
            if (isDoubleDown && !BankrollManager.CanDoubleDown)
            {
                return;
            }
            gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            EventUtility.Unsubscribe(typeof(OnStartButtonClickedEventArgs), OnStartButtonClicked);
            EventUtility.Unsubscribe(typeof(OnPlayerHitEventArgs), OnPlayerHit);
            EventUtility.Unsubscribe(typeof(OnPlayerStayEventArgs), OnPlayerStay);
            EventUtility.Unsubscribe(typeof(OnGameEndEventArgs), OnGameEnd);
        }
    }
}