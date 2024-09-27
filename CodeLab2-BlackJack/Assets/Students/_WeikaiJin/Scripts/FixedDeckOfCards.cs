using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weikai
{
    public class FixedDeckOfCards : DeckOfCards
    {
        protected override bool IsValidDeck()
        {
            if(deck == null) return false;
            return deck.Count >= 20;
        }

        protected override void AddCardsToDeck()
        {
            for (int i = 0; i < 4; i++)
                base.AddCardsToDeck();
        }
    }
}