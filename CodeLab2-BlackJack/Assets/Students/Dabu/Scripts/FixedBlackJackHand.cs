using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DabuLyu
{
    public class FixedBlackJackHand : BlackJackHand
    {
        protected override void SetupHand()
        {
            base.SetupHand();
            NaturalBlackJackCheck();
            
        }
        
        protected override void ShowValue()
        {
            //base.ShowValue();
            FixedBlackJackManager manager = GameObject.Find("BlackJackManager").GetComponent<FixedBlackJackManager>();
            handVals = manager.BlackJackGetHandValue(hand);
			
            total.text = "Player: " + handVals;

            if(handVals > 21){
                GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().PlayerBusted();
            }
            
        }
        
        
        public void NaturalBlackJackCheck()
        {
            FixedBlackJackManager manager = GameObject.Find("BlackJackManager").GetComponent<FixedBlackJackManager>();
            if (hand.Count == 2 && hand[0].GetCardHighValue() == 10 && hand[1].GetCardHighValue() == 11)
            {
                manager.PlayerWin();
            }
        }
    }

}
