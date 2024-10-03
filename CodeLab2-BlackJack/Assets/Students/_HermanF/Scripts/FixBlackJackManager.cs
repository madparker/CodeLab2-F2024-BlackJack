using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HermanF
{
    public class FixBlackJackManager : BlackJackManager
    {
        public override int GetHandValue(List<DeckOfCards.Card> hand)
        {
            //initialize value
            int handVaule = 0;
            int aceCount = 0;
            
            
            foreach (DeckOfCards.Card card in hand)
            {
                //track the ace count
                if (card.cardNum == DeckOfCards.Card.Type.A)
                {
                    aceCount++;
                }

                //add value to hand
                handVaule += card.GetCardHighValue();
            }
            
            while (handVaule > 21 && aceCount > 0)
            {
                handVaule -= 10;
                aceCount--;
            }
            
            return handVaule;
        }

        public override void TryAgain()
        {
            SceneManager.LoadScene(loadScene);
            //GameManager.instance.RestartGame();
            GameManager.instance.damageable = true;
        }
    }
}

