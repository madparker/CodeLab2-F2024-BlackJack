using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DabuLyu
{
    public class FixedBlackJackHand : BlackJackHand
    {
        public GameObject clearButton;
        public int selectedCardIndex = 0;
        
        public List<DeckOfCards.Card> clearCheckCards = new List<DeckOfCards.Card>();
        public List<GameObject> clearCheckCardObjs = new List<GameObject>();
        protected override void SetupHand()
        {
            base.SetupHand();
            //NaturalBlackJackCheck();
            AddSelectables();
            
            //clearButton = GameObject.Find("ClearButton");
            
        }
        
        protected override void ShowValue()
        {
            //base.ShowValue();
            FixedBlackJackManager manager = GameObject.Find("BlackJackManager").GetComponent<FixedBlackJackManager>();
            handVals = manager.BlackJackGetHandValue(hand);
			
            total.text = "Player: " + handVals;

            if(handVals > 21){
                GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().PlayerBusted();
            }
            
        }
        
        public void AddSelectables()
        {
            for (int i = 0; i < hand.Count; i++)
            {
                
                GameObject cardObj = handBase.transform.GetChild(i).gameObject;
                //check if the card has the SelectableCard script
                if (cardObj.GetComponent<SelectableCard>() == null)
                    cardObj.AddComponent<SelectableCard>();
            }
        }
        
        
        public void NaturalBlackJackCheck()
        {
            FixedBlackJackManager manager = GameObject.Find("BlackJackManager").GetComponent<FixedBlackJackManager>();
            if (hand.Count == 2 && hand[0].GetCardHighValue() == 10 && hand[1].GetCardHighValue() == 11)
            {
                manager.PlayerWin();
            }
        }

        public void ClearPairCheck()
        {
            //check two cards if they are the same card number or suit
            
            if (clearCheckCards[0].cardNum == clearCheckCards[1].cardNum || clearCheckCards[0].suit == clearCheckCards[1].suit)
            { 
                clearButton.SetActive(true);
            }
            
        }
        
        public void ClearPair()
        {
            //remove the two cards from the hand
            hand.Remove(clearCheckCards[0]);
            hand.Remove(clearCheckCards[1]);
            
            //destroy the two cards
            
            Destroy(clearCheckCardObjs[0]);
            Destroy(clearCheckCardObjs[1]);
            
            //reset the clearCheckCards list
            clearCheckCards.Clear();
            clearCheckCardObjs.Clear();
            
            //reset the selectedCardIndex
            selectedCardIndex = 0;
            
            //hide the clear button
            clearButton.SetActive(false);
            UpdateCardPositions();
            //update the hand value
            ShowValue();
        }
        
        public List<DeckOfCards.Card> GetHand()
        {
            return hand;
        }
        
        public void UpdateCardPositions()
        {
            for (int i = 0; i < hand.Count; i++)
            {
                RectTransform cardTransform = handBase.transform.GetChild(i).GetComponent<RectTransform>();


                float currentY = cardTransform.anchoredPosition.y; 
                cardTransform.anchoredPosition = new Vector2(xOffset + i * 110, currentY);
            }
        }

    }

}
