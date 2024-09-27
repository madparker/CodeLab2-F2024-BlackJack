using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EzrealYe {
    public class FixedBlackJackManager : BlackJackManager
    {
        public override int GetHandValue(List<DeckOfCards.Card> hand)
        {
            int handValue = 0; //stores the total value of the card in hand
            int aceCount = 0; //store the number of A on hand

            // using for each to go through each card
            foreach (DeckOfCards.Card handCard in hand) 
            {
                //get the highest possible value of each card
                int cardValue = handCard.GetCardHighValue();
                
                //count the scores
                handValue += cardValue;

                // compare the card num to see if the card in hand is Ace
                if (handCard.cardNum == DeckOfCards.Card.Type.A) 
                {
                    //if true, increment ace count
                    aceCount++;
                }
            }

            // if hand value is greater than 22 && there is more than 0 Ace card in hand
            while (handValue > 21 && aceCount > 0) 
            {
                // minus 10 points from the total hand value

                // I directly subtract 10 points from the total score, since it's more efficient than adjusting the actual value of each Ace
                // for example, if the total score exceeds 21 while the player has multiple Aces, the program just needs to treat one Ace as 1 instead of 11.
                // if the player draws another card and the total exceeds 21 again, the program will repeat the process by treating another Ace as 1, 
                // without needing to adjust the value of each Ace individually

                //and it's less complex than dealing with assigning Ace different values...

                handValue -= 10;

                // ace Count minus 1, and it means this specific Ace is already being processed
                aceCount--;
            }

            return handValue; // return the final hand Value after calculating Ace's special rules
        }
    }
}

