using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyriBlackJackManager : BlackJackManager
{
    public override int GetHandValue(List<DeckOfCards.Card> hand){
        int handValue = 0;

        foreach(DeckOfCards.Card handCard in hand){
            handValue += handCard.GetCardHighValue();
        }
        return handValue;
    }
}
