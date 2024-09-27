using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

namespace IsabelLiang
{
    public class FixedBlackJackManager : BlackJackManager
    {
        // Adds all the cards together to get the hand value
        public override int GetHandValue(List<DeckOfCards.Card> hand)
        {
            int handValue = 0;  // Initialize total hand value
            int aceNum = 0;     // Counter to track the number of Aces in the hand

            // First, iterate through all the cards in the hand
            foreach (DeckOfCards.Card handCard in hand)
            {
                // If the card is an Ace, increment the ace counter
                if (handCard.cardNum == DeckOfCards.Card.Type.A)
                {
                    aceNum++;
                }
        
                // Add the card's value to the hand total
                // Note: This adds the Ace as 11 initially (GetCardHighValue presumably returns 11 for Ace)
                handValue += handCard.GetCardHighValue();
            }

            // After adding all card values, adjust the value for any Aces if necessary
            // Aces are initially counted as 11, but if the total hand value exceeds 21, 
            // we reduce the value of one or more Aces from 11 to 1
            for (int i = 0; i < aceNum; i++)
            {
                // If the total hand value exceeds 21, subtract 10 (which effectively turns an Ace from 11 to 1)
                if (handValue > 21)
                {
                    handValue -= 10;
                }
            }
            
            //Natural Blackjack
            if (hand.Count == 2 && handValue == 21)
            {
                BlackJack();
            }
    
            // Return the final hand value
            return handValue;
        }

        
        
        //try again button reloads the scene
        public void TryAgain(){
            SceneManager.LoadScene("IsabelBlackJack");
        }
        
    }
}

