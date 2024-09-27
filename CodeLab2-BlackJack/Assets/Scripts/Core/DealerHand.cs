using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DealerHand : BlackJackHand {

	public Sprite cardBack;

	bool reveal;

	//sets up the dealers hand with two cards and sets one of them to be face down
	protected override void SetupHand(){
		base.SetupHand();

		GameObject cardOne = transform.GetChild(0).gameObject;
		cardOne.GetComponentInChildren<Text>().text = ""; //sets the text that would show the card type (1, 3, K, J) to a blank space
		cardOne.GetComponentsInChildren<Image>()[0].sprite = cardBack; //sets the sprite of the card to the back of the card
		cardOne.GetComponentsInChildren<Image>()[1].enabled = false; //disables the suit's sprite

		reveal = false;
	}
		
	protected override void ShowValue(){
		
		// if the dealer has more than one card
		if(hand.Count > 1){
			//and if the second card has not been revealed
			if(!reveal){
				//the hand value is set to the value of the first card only
				handVals = hand[1].GetCardHighValue();
				
				//and we print the hand value with a + ??? to indicate the mystery value of the uncovered card
				total.text = "Dealer: " + handVals + " + ???";
			} else {
				//if the second card is revealed, get the actual total value of the dealer's hand
				handVals = GetHandValue();
				
				// and set the text to print that value
				total.text = "Dealer: " + handVals;
				
				// find the black jack manager script to use its functions
				BlackJackManager manager = GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>();
				
				//if the hand total is over 21
				if(handVals > 21){
					//the dealer busted and the game ends with the appropriate conditions
					manager.DealerBusted();
				} else if(!DealStay(handVals)){
					//else if the dealer's hand value has not yet reached 17-21
					//they will draw another card
					Invoke("HitMe", 1);
				} else {
					//else if the dealer's hand value is between 17 and 21, the game checks the player hand
					BlackJackHand playerHand = GameObject.Find("Player Hand Value").GetComponent<BlackJackHand>();
					
					//if the dealer's hand value is less than the player's hand value
					if(handVals < playerHand.handVals){
						//the player wins
						manager.PlayerWin();
						
						// if the dealer's hand value is higher
					} else {
						//the house wins
						manager.PlayerLose();
					}
				}
			}
		}
	}

	protected virtual bool DealStay(int handVal){
		//if the value is over 17 the dealer will stay and not draw another card
		
		return handVal > 17;
	}

	public void RevealCard(){
		//once reveal is true
		reveal = true;

		//set cardOne to the first card in the hand
		GameObject cardOne = transform.GetChild(0).gameObject;

		//set the second cards sprite to true
		cardOne.GetComponentsInChildren<Image>()[0].sprite = null;
		cardOne.GetComponentsInChildren<Image>()[1].enabled = true;

		ShowCard(hand[0], cardOne, 0);

		ShowValue();
	}
}
