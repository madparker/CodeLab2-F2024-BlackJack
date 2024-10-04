using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VivianChen
{
    public class VivianFixedBlackJackManager : BlackJackManager
    {
        /// <summary>
        /// This mod allows players to accumulate 50 points each time they hit,
        /// and when they reach 100 points,
        /// the player can choose to consume 100 points to burn the last card drawn.
        /// </summary>
        
        // Introduce a new button and new text for counting the "point"
        private GameObject burnButton;

        public int point;
        public Text pointText;
        
        private void Start()
        {
            // Finding the button, and deactivate it at the beginning of the game
            burnButton = GameObject.Find("BurnButton");
            burnButton.SetActive(false);
            
            // Reset the point to 0
            point = 0;
            UpdatePoints();
        }

        public override int GetHandValue(List<DeckOfCards.Card> hand)
        {
            int handValue = 0;
            
            // For counting the amount of ace(s)
            int aceCount = 0;

            // By default, going through the high value
            // Looping through the hand cards
            foreach(DeckOfCards.Card handCard in hand){
                handValue += handCard.GetCardHighValue();

                // Find out how many ace(s) the player has
                if (handCard.cardNum == DeckOfCards.Card.Type.A)
                {
                    aceCount++;
                }
            }

            // If the player's hand total value exceeds 21 (player in disadvantage)
            // progressively, change the value of ace from 11 to 1
            // until the total value no longer exceeds 21 or there are no more Aces
            while (handValue > 21 && aceCount > 0)
            {
                handValue -= 10;
                aceCount--;
            }
            
            //Debug.Log("HAND VALUE: " + handValue);
            
            return handValue;
        }

        public void UpdatePoints()
        {
            // Update UI display
            pointText.text = "POINTS: " + point;

            // If the player has enough points, allow the player to burn a card
            if (point >= 100)
            {
                burnButton.SetActive(true);
            }
            else
            {
                burnButton.SetActive(false);
            }
        }

        public void BurnCard()
        {
            // Consume 100 points
            point -= 100;
            
            // Abandon the last card
            List<DeckOfCards.Card> hand = 
                GameObject.Find("Player Hand Value").GetComponent<VivianFixedBlackJackHand>().GetHand();

            // Remove the data of the last card in the list
            hand.RemoveAt(hand.Count - 1);
            
            // Update the display 
            GameObject.Find("Player Hand Value").GetComponent<VivianFixedBlackJackHand>().GetShowValue();
            
            // Destroy the gameobject
            GameObject lastCard = GameObject.Find("Player Hand Value").transform.GetChild(hand.Count).gameObject;
            Destroy(lastCard);
        }
        
        // Reset points and hide button
        public override void PlayerWin()
        {
            base.PlayerWin();

            point = 0;
            UpdatePoints();
        }

        public override void PlayerLose()
        {
            base.PlayerLose();
            
            point = 0;
            UpdatePoints();
        }

        public override void PlayerBusted()
        {
            base.PlayerBusted();
            
            point = 0;
            UpdatePoints();
        }

        public override void DealerBusted()
        {
            base.DealerBusted();
            
            point = 0;
            UpdatePoints();
        }
    }
}
