using System.Collections.Generic;

namespace Students._NengkuanChen.Scripts
{
    public class FixedBlackJackManager : BlackJackManager
    {
        
        public override int GetHandValue(List<DeckOfCards.Card> hand)
        {
            var handVal = 0;
            var aceCount = 0;
            foreach (var card in hand)
            {
                if (card.cardNum == DeckOfCards.Card.Type.A)
                {
                    aceCount++;
                }

                handVal += card.GetCardHighValue();
            }
            
            while (handVal > 21 && aceCount > 0)
            {
                handVal -= 10;
                aceCount--;
            }
            
            return handVal;
        }
    }
}