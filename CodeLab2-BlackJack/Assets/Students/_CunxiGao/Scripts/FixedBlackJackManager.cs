using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CunxiGao
{
    public class FixedBlackJackManager : BlackJackManager
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        
        public override int GetHandValue(List<DeckOfCards.Card> hand)
        {
            int handValue = 0;
            int aceCount = 0;

            // Adds the value first，while counting the number of A cards
            foreach(DeckOfCards.Card handCard in hand){
                handValue += handCard.GetCardHighValue();
                if(handCard.cardNum == DeckOfCards.Card.Type.A){
                    aceCount++;
                }
            }

            // If the total value exceeds 21 and there are Aces in hand, change the value of Aces from 11 to 1
            while(handValue > 21 && aceCount > 0){
                handValue -= 10; // Reduce Ace value from 11 to 1
                aceCount--;
            }

            return handValue;
        }
    }
}
