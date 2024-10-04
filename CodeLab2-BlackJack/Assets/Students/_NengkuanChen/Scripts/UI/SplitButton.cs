using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Students._NengkuanChen.Scripts.UI
{
    public class SplitButton : MonoBehaviour
    {
        [SerializeField]
        private Button splitButton;
        
        private void Awake()
        {
            splitButton.onClick.AddListener((() =>
            {
                EventUtility.TriggerNow(this, new OnPlayerSplitCardEventArgs());
                gameObject.SetActive(false);
            }));
            EventUtility.Subscribe(typeof(OnSplitEnableEventArgs), OnSplitEnable);
            EventUtility.Subscribe(typeof(OnPlayerHitEventArgs), OnPlayerHit);
            gameObject.SetActive(false);
        }

        private void OnPlayerHit(object sender, GameEventArgs args)
        {
            gameObject.SetActive(false);
        }

        private void OnSplitEnable(object sender, GameEventArgs args)
        {
            gameObject.SetActive(true);
        }
        
        private void OnDestroy()
        {
            EventUtility.Unsubscribe(typeof(OnSplitEnableEventArgs), OnSplitEnable);
            EventUtility.Unsubscribe(typeof(OnPlayerHitEventArgs), OnPlayerHit);
        }
    }
}