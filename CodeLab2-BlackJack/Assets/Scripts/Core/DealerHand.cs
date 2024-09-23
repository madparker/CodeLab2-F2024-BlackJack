using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DealerHand : BlackJackHand {

	public Sprite cardBack;

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
		
	protected override void ShowValue(){
		
		// if the dealer has more than one card
		if(hand.Count > 1){
			//and if the second card has not been revealed
			if(!reveal){
				//the hand value is the first card value
				handVals = hand[1].GetCardHighValue();
				//the second card is concealed so we use + ??? to show it
				total.text = "Dealer: " + handVals + " + ???";
			} else {
				//otherwise get the hand value
				handVals = GetHandValue();
				
				// and put it to text
				total.text = "Dealer: " + handVals;
				
				// find the black jack manager script to use to see-
				BlackJackManager manager = GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>();
				
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

	protected virtual bool DealStay(int handVal){
		//if the value is over 17 the dealer will stay and not draw
		return handVal > 17;
	}

	public void RevealCard(){
		//once reveal is true
		reveal = true;

		//set card one to the first card in the hand
		GameObject cardOne = transform.GetChild(0).gameObject;

		//set the second cards sprite to true
		cardOne.GetComponentsInChildren<Image>()[0].sprite = null;
		cardOne.GetComponentsInChildren<Image>()[1].enabled = true;

		ShowCard(hand[0], cardOne, 0);

		ShowValue();
	}
}
