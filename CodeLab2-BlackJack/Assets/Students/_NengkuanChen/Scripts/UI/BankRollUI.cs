using System;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Students._NengkuanChen.Scripts.UI
{
    public class BankRollUI : MonoBehaviour
    {
        [SerializeField]
        private Text bankRollText;

        private void Awake()
        {
            EventUtility.Subscribe(typeof(OnBankRollChangedEventArgs), OnBankRollChanged);
            bankRollText.text = $"Bankroll:\n {BankrollManager.Bankroll}";
        }

        private void OnBankRollChanged(object sender, GameEventArgs args)
        {
            if (args is OnBankRollChangedEventArgs bankRollChangedArgs)
            {
                bankRollText.text = $"Bankroll:\n {bankRollChangedArgs.To}";
            }
        }
        
        private void OnDestroy()
        {
            EventUtility.Unsubscribe(typeof(OnBankRollChangedEventArgs), OnBankRollChanged);
        }
    }
}