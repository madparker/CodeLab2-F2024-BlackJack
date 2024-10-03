using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CunxiGao
{
    public class FixedBlackJackHand : BlackJackHand
    {
        private bool hasReplaced = false;
        public GameObject cheatButton;
        
        public void ReplaceCard()
        {
            if (!hasReplaced && hand.Count > 0)
            {
                int randomIndex = Random.Range(0, hand.Count);

                DeckOfCards.Card newCard = deck.DrawCard();
        
                //replace a random card with a new card
                hand[randomIndex] = newCard;
        
                //update the card and value on the screen
                GameObject cardObj = handBase.transform.GetChild(randomIndex).gameObject;
                ShowCard(newCard, cardObj, randomIndex);
        
                ShowValue();
        
                hasReplaced = true;
                cheatButton.SetActive(false);
            }
        }
    }
}
