using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AllisonTerry
{
    
    
    public class FixedBlackJackManagerScript : BlackJackManager
    {

        protected BlackJackHand blackJackHand;

        private void Start()
        {
            /*blackJackHand = GetComponent<BlackJackHand>();
            if (blackJackHand.handVals == 21)
            {
                GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().BlackJack();
            }*/
        }

        public override int GetHandValue(List<DeckOfCards.Card> hand)
        {
            //first get the value of the initial hand
            int handValue = base.GetHandValue(hand);
            
            //keep track of the number of aces in a hand
            int playerAces = 0;
            int newHandValue = 0;

            //if the player is about to bust
            if (handValue > 21)
            {
                //set the hand value back to 0
                
                //go back through the hand
                foreach (DeckOfCards.Card handCard in hand)
                {
                    //and if they have an ace
                    if (handCard.cardNum == DeckOfCards.Card.Type.A)
                    {
                        print("this is an ace");
                        if (playerAces == 0 && handValue < 21 )
                        {
                            playerAces++;
                            newHandValue += handCard.GetCardHighValue();
                        }
                        else if (playerAces == 0)
                        {
                            playerAces++;
                            //add one to the hand value instead
                            newHandValue += 1;
                        }
                        else if (playerAces > 1)
                        {
                            playerAces++;
                            //add one to the hand value instead
                            newHandValue += 1;
                        }
                   

                    }
                    //else just add the card to the hand
                    else
                    {
                        newHandValue += handCard.GetCardHighValue();
                    }
                }

                return newHandValue;
            }

            playerAces = 0;
            return handValue;

        }
    }
}
