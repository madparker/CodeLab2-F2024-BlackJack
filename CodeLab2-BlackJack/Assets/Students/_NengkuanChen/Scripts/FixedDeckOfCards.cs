using System.Collections.Generic;
using UnityEngine;

namespace Students._NengkuanChen.Scripts
{
    public class FixedDeckOfCards : DeckOfCards
    {
        
        
#if DEBUG_DECK
        private int drawCount = 0;
#endif
        protected override void AddCardsToDeck()
        {
            deck?.Clear();
            for (int i = 0; i < 4; i++)
            {
                base.AddCardsToDeck();
            }
        }

        protected override bool IsValidDeck()
        {
            return deck?.Count > 19;
        }

        public override Card DrawCard()
        {
            if (!IsValidDeck())
            {
                AddCardsToDeck();
            }
            var drawnCard = base.DrawCard();
            deck.Remove(drawnCard);
#if DEBUG_DECK
            return DrawCardDebug();
#endif
            return drawnCard;
        }
        
        

#if DEBUG_DECK
        private DeckOfCards.Card DrawCardDebug()
        {
            List<int> cards = new List<int>();
            //read the deck from persistent data
            string path = Application.persistentDataPath + "/DebugDeck.txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                cards.Add(int.Parse(line));
            }
            return new DeckOfCards.Card((DeckOfCards.Card.Type)cards[drawCount++], Card.Suit.CLUBS);
        }
#endif
    }
}