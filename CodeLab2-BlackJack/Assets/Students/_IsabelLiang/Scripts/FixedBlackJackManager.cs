using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

namespace IsabelLiang
{
    public class FixedBlackJackManager : BlackJackManager
    {
        public int chances = 3;//chances of busted save
        public int temp = 0;//handValue after busted save
        public int temp2 = 0;//real accumulated handValue after busted save
        public int temp3 = 0;//card pulled last time after busted save
        public bool dealer = false;//mark true when dealer acts
        public GameObject textChance;
        
        // Adds all the cards together to get the hand value
        public override int GetHandValue(List<DeckOfCards.Card> hand)
        {
            int handValue = 0;  // Initialize total hand value
            int aceNum = 0;     // Counter to track the number of Aces in the hand
            
            // First, iterate through all the cards in the hand
            foreach (DeckOfCards.Card handCard in hand)
            {
                // If the card is an Ace, increment the ace counter
                if (handCard.cardNum == DeckOfCards.Card.Type.A)
                {
                    aceNum++;
                }
        
                // Add the card's value to the hand total
                // Note: This adds the Ace as 11 initially (GetCardHighValue presumably returns 11 for Ace)
                handValue += handCard.GetCardHighValue();
            }

            // After adding all card values, adjust the value for any Aces if necessary
            // Aces are initially counted as 11, but if the total hand value exceeds 21, 
            // we reduce the value of one or more Aces from 11 to 1
            for (int i = 0; i < aceNum; i++)
            {
                // If the total hand value exceeds 21, subtract 10 (which effectively turns an Ace from 11 to 1)
                if (handValue > 21)
                {
                    handValue -= 10;
                }
            }
            
            if (dealer) return handValue;//Dealer does not have chances
            
            if (chances == 3)//set temp if player uses chance; temp is the real hand value after busted save
            { 
                temp = handValue;
                temp2 = handValue;//save the real handValue
            }
            else
            {
                temp3 = handValue - temp2;//current real handValue - previous real handValue (The card value added this time)
                temp2 = handValue;//save the real handValue
                handValue = temp + temp3;//simulate the handValue after last bused save + card value added this time
            }
            
            if (handValue > 21 && chances > 0)//if player busted but chances left
            {
                chances -= 1;//decrease one chance
                handValue = 21 - (handValue - 21);//change handValue to busted-saved hand value
                temp = handValue;//record the current hand value for next chance usage
                textChance.GetComponent<Text>().text = "Chances Remaining: " + chances;//update chances remaining text
            }
            
            //Natural Blackjack
            if (hand.Count == 2 && handValue == 21)
            {
                BlackJack();
            }
    
            // Return the final hand value
            return handValue;
        }
        


        public void ResetChances()//called when dealer gets to use chances
        {
            chances = 3;
            temp = 0;
            temp2 = 0;
            temp3 = 0;
            dealer = true;
            
            textChance.GetComponent<Text>().text = "Dealer Moves";//update chances remaining text
        }
        
        
        //try again button reloads the scene
        public void TryAgain(){
            SceneManager.LoadScene(loadScene);
        }
        
    }
}

