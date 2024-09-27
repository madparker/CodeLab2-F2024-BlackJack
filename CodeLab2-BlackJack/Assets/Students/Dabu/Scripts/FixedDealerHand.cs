using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DabuLyu
{
    public class FixedDealerHand : DealerHand
    {
        //public Sprite cardBack;

        bool reveal;

        //set up the dealers hand by showing one card and having another face down
        protected override void SetupHand(){
            base.SetupHand();

            GameObject cardOne = transform.GetChild(0).gameObject;
            cardOne.GetComponentInChildren<Text>().text = "";
            cardOne.GetComponentsInChildren<Image>()[0].sprite = cardBack;
            cardOne.GetComponentsInChildren<Image>()[1].enabled = false;

            reveal = false;
        }

        protected override void ShowValue()
        {
            // if the dealer has more than one card
            if(hand.Count > 1){
                //and if the second card has not been revealed
                if(!reveal){
                    //the hand value is the first card value
                    handVals = hand[1].GetCardHighValue();
                    //the second card is concealed so we use + ??? to show it
                    total.text = "Dealer: " + handVals + " + ???";
                } else {
                    FixedBlackJackManager manager = GameObject.Find("BlackJackManager").GetComponent<FixedBlackJackManager>();
                    
                    handVals = manager.DealerGetHandValue(hand);
				
                    // and put it to text
                    total.text = "Dealer: " + handVals;
				
                    // find the black jack manager script to use to see-
                    
				
                    //if the hand total is over 21
                    if(handVals > 21){
                        //the dealer busted
                        manager.DealerBusted();
                    } else if(!DealStay(handVals)){
                        //else if the dealer does not have 17 yet
                        //they will hit for another card once and then run this again
                        Invoke("HitMe", 1);
                    } else {
                        //else they will look at the player hand
                        BlackJackHand playerHand = GameObject.Find("Player Hand Value").GetComponent<BlackJackHand>();
					
                        //and if the dealer hand is less than the player hand
                        if(handVals < playerHand.handVals){
                            //player wins
                            manager.PlayerWin();
                        } else {
                            //house wins
                            manager.PlayerLose();
                        }
                    }
                }
            }
        }
        
        
        protected override bool DealStay(int handVal){
            //if the value is over 17 the dealer will stay and not draw
            return handVal >= 17;
        }


    }
}

