using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DabuLyu
{
    public class FixedDeckOfCards : DeckOfCards
    {
        void Awake()
        {
            if(!IsValidDeck()){
                deck = new ShuffleBag<Card>();

                AddCardsToDeck();
            }

            Debug.Log("Cards in Deck: " + deck.Count);
        }

        protected override void AddCardsToDeck()
        {
            
            base.AddCardsToDeck();
            for (int i = 0; i < 3; i++) {
                foreach (Card.Suit suit in Card.Suit.GetValues(typeof(Card.Suit))){
                    foreach (Card.Type type in Card.Type.GetValues(typeof(Card.Type))){
                        deck.Add(new Card(type, suit));
                    }
                }
            }
        }
        
        
        public void DebugDeckNum()
        {
            Debug.Log("Cards in Deck: " + deck.Count);
        }
    }

}
