using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VivianChen;

namespace VivianChen
{
    public class VivianFixedBlackJackHand : BlackJackHand
    {
        // Before the setup finished, do not add points 
        private bool isSetUpFinished = false;
        
        protected override void SetupHand()
        {
            base.SetupHand();

            isSetUpFinished = true;

            // Natural Black Jack: If player starts with 21, player automatically wins
            if (handVals == 21)
            {
                Debug.Log("Natural Black Jack");
                
                GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().BlackJack();
            }
        }

        public void AddPoints()
        {
            GameObject.Find("BlackJackManager").GetComponent<VivianFixedBlackJackManager>().point += 50;
            GameObject.Find("BlackJackManager").GetComponent<VivianFixedBlackJackManager>().UpdatePoints();
        }
        
        // Public method to expose the protected hand
        public List<DeckOfCards.Card> GetHand()
        {
            return base.hand;
        }
        
        // Public the show value function
        public void GetShowValue()
        {
            base.ShowValue();
        }
    }
}
