using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Students._NengkuanChen.Scripts.UI
{
    public class PotSizeUI : MonoBehaviour
    {
        [SerializeField]
        private Text potSizeText;
        
        
        private void Awake()
        {
            EventUtility.Subscribe(typeof(OnPotSizeChangedEventArgs), OnPotSizeChanged);
        }



        private void OnPotSizeChanged(object sender, GameEventArgs args)
        {
            if (args is OnPotSizeChangedEventArgs potSizeChangedArgs)
            {
                potSizeText.text = $"Pot Size:\n {potSizeChangedArgs.To}";
            }
        }
        
        private void OnDestroy()
        {
            EventUtility.Unsubscribe(typeof(OnPotSizeChangedEventArgs), OnPotSizeChanged);
        }
    }
}