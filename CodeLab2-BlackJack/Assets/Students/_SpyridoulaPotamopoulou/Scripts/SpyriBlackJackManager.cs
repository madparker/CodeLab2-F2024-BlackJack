using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyriBlackJackManager : BlackJackManager
{
    public override int GetHandValue(List<DeckOfCards.Card> hand)
    {
        //gets the actual value of the player's hand
        int handValue = base.GetHandValue(hand);

        //if that hand value is over 21 (i.e. if the player is about to bust)
        if (handValue > 21)
        {
            //check each card in the player's hand
            foreach (DeckOfCards.Card handCard in hand)
            {
                //if there are any aces, subtract 10 from the current value of the player's hand
                //thus turning the value of any ace from an 11 to a 1, preventing a bust
                //unless the player hit on a 21, in which case, they deserve to lose
                if (handCard.cardNum == DeckOfCards.Card.Type.A)
                {
                    handValue -= 10;
                }
            }
            return handValue;
        }
        return handValue;
    }
}
