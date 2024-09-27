using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Weikai
{
    public class FixedBlackJackHand : BlackJackHand
    {
        protected override void ShowValue()
        {
            //gets the total value of the player's hand
            handVals = GetHandValue();
		
            //changes the text on screen to the total value of the player's hand			
            total.text = "Player: " + handVals;

            //if the hand's value is over 21, the player busts
            if(handVals > 21){
                GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().PlayerBusted();
            }

            if (handVals == 21)
            {
                GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().BlackJack();
            }
        }
    }

}