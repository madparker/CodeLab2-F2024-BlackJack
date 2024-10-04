using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Students._NengkuanChen.Scripts.UI
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField]
        private Button startButton;
        
        private void Awake()
        {
            startButton.onClick.AddListener(() =>
            {
                EventUtility.TriggerNow(this, new OnStartButtonClickedEventArgs());
                gameObject.SetActive(false);
            });
        }
        
    }
}