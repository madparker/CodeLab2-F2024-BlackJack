using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DabuLyu
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

        // public override int GetHandValue(List<DeckOfCards.Card> hand)
        // {
        //     int handValue = base.GetHandValue(hand);
        //     
        //     
        //     int aceCount = 0;
        //     
        //     foreach (DeckOfCards.Card card in hand)
        //     {
        //         
        //         if (card.GetCardHighValue() == 11)
        //         {
        //             aceCount++;
        //         }
        //     }
        //     
        //     while (handValue > 21 && aceCount > 0)
        //     {
        //         handValue -= 10;
        //         aceCount--;
        //     }
        //     
        //     return handValue;
        //     
        //
        //     
        //}

        public int BlackJackGetHandValue(List<DeckOfCards.Card> hand)
        {
            int handValue = 0;
            int aceCount = 0;
            
            foreach (DeckOfCards.Card card in hand)
            {
                handValue += card.GetCardHighValue();
                
                if (card.GetCardHighValue() == 11)
                {
                    aceCount++;
                }
            }
            
            while (handValue > 21 && aceCount > 0)
            {
                handValue -= 10;
                aceCount--;
            }
            
            return handValue;
        }
        
        
        public int DealerGetHandValue(List<DeckOfCards.Card> hand)
        {
            int handValue = 0;
            int aceCount = 0;
            
            foreach (DeckOfCards.Card card in hand)
            {
                handValue += card.GetCardHighValue();
                
                if (card.GetCardHighValue() == 11)
                {
                    aceCount++;
                }
            }
            
            //to make sure the dealer bust or smaller than player
            while (aceCount > 0 && handValue < 21)
            {
                handValue -= 10;
                aceCount--;
            }
            
    

            return handValue;

        }
    }

}
