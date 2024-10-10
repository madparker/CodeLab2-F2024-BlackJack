using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlexandraAnderson
{
    public class AlexandraFixedBlackJackManager : BlackJackManager
    {
        DeckOfCards deck;

        public Button betbtn;
        
        [SerializeField] GameObject hitButton, stayButton;
        [SerializeField] private AlexandraFixedBlackJackHand playerHand;
        [SerializeField] private AlexandraFixedDealerHand dealerHand;
        
        public void FixedTryAgain()
        {
            //checking how many cards are remaining in the deck
            if (DeckOfCards.deck.Count < 20)
            {
                TryAgain();
            }
            else
            {
                //Turn off Game Over UI
                tryAgain.SetActive(false);
                statusText.text = "";
                
                //turn back on the UI
                hitButton.SetActive(true);
                stayButton.SetActive(true);
                
                //clear old cards
                playerHand.ResetHand();
                dealerHand.ResetHand();
            }

        }
        public override int GetHandValue(List<DeckOfCards.Card> hand)
        {
            int handValue = 0;
            
            // For counting the number of ace(s)
            int aceCount = 0;

            // By default, going through the high value
            // Looping through the hand cards
            foreach(DeckOfCards.Card handCard in hand){
                handValue += handCard.GetCardHighValue();

                // Find out how many ace(s) the player has
                if (handCard.cardNum == DeckOfCards.Card.Type.A)
                {
                    aceCount++;
                }
            }

            // If the player's hand total value exceeds 21 (player in disadvantage)
            // progressively, change the value of ace from 11 to 1
            // until the total value no longer exceeds 21 or there are no more Aces
            while (handValue > 21 && aceCount > 0)
            {
                handValue -= 10;
                aceCount--;
            }
            
            Debug.Log("HAND VALUE: " + handValue);
            
            return handValue;
            
        }
        
    }
}

