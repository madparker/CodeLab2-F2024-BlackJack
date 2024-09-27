using UnityEngine;

namespace Students._NengkuanChen.Scripts
{
    public class FixedBlackJackHand : BlackJackHand
    {
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
    }
}