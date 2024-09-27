using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Weikai
{
    public class FixedBlackJackManager : BlackJackManager
    {
        // Start is called before the first frame update
        public override int GetHandValue(List<DeckOfCards.Card> hand)
        {
            int handValue = 0;
            int aceCnt = 0;
            foreach(DeckOfCards.Card handCard in hand)
            {
                handValue += handCard.GetCardHighValue();
                if (handCard.cardNum == DeckOfCards.Card.Type.A)
                    aceCnt++;
            }

            if (handValue > 21)
            {
                // (handValue-12) / 10 equals to : Ceil((float)handValue - 21f) / 10f)
                // which is the number of Aces that need to be count as 1, instead of 11
                int acesToReduce = System.Math.Min(aceCnt, (handValue-12) / 10);
                handValue -= acesToReduce * 10;
            }
            
            if(hand.Count  == 2 && handValue == 21)
                BlackJack();
            
            return handValue;
        }
    }

}