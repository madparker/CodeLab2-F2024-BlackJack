using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Weikai
{
   
    public class ModdedDeckOfCards : FixedDeckOfCards
    {
        public Card topCard = null;
        public GameObject cheatCard;
        void Start()
        {
            topCard = deck.Next();
            Debug.Log(topCard);
            cheatCard = GameObject.Find("CheatCard");
            ShowCheatCard();
        }
        
        
        public override Card DrawCard(){
            
            Card ret = topCard;
            topCard = deck.Next();
            ShowCheatCard();
            return ret;
        }

        //takes the suit and number value of the card object that is passed into this function
        //and places a card Game Object with that information on it at a specific position on the game screen
        public void ShowCheatCard(){
            
            //sets the text of the text object childed to this cardObj to the card's type (1, 2, J, K, etc.)
            cheatCard.GetComponentInChildren<Text>().text = GetNumberString(topCard); 
		
            //sets the sprite childed to this cardObj to the sprite depicting the suit of the card
            cheatCard.GetComponentsInChildren<Image>()[1].sprite = GetSuitSprite(topCard);
        }
        
    }
}
