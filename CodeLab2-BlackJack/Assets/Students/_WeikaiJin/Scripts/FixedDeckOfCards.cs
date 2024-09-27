using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weikai
{
    public class FixedDeckOfCards : DeckOfCards
    {
        protected override void AddCardsToDeck()
        {
            for (int i = 0; i < 4; i++)
                base.AddCardsToDeck();
        }
    }
}