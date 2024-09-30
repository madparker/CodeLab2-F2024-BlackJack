using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AllisonTerry
{
   public class FixedBlackJackHand : BlackJackHand
   {
       protected DeckOfCards.Card extraCard;
       protected GameObject extraCardObj;
       public GameObject UseButton;
       int cheatNumber =0;
       public string jailScene;

       protected override void SetupHand()
       {
           


           base.SetupHand();
           if(handVals == 21){
               GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().BlackJack();
           }
           //run the hit extra function
           HitExtra();

       }


       //hit extra function
       //on set up add an extra card on the side and show the use button
       public void HitExtra()
       {
           UseButton.SetActive(true);
           // find the deck of cards
           deck = GameObject.Find("Deck").GetComponent<DeckOfCards>();

           // draw a card from the deck
           extraCard = deck.DrawCard();

           //instantiate that card to a game object
           extraCardObj = Instantiate(Resources.Load("prefab/Card")) as GameObject;

           //show card which takes the values of the card info, the card object and a int position
           ShowCard(extraCard, extraCardObj, -2);
       }


       // use button function adds the card to the players hand

       public void UseCard()
       {
           if (cheatNumber > 3)
           {
               SceneManager.LoadScene(jailScene);
           }
           cheatNumber++;
           UseButton.SetActive(false);
           hand.Add(extraCard);
           ShowCard(extraCard,extraCardObj, hand.Count-1);
           ShowValue();
           print(cheatNumber);
       }

   }

}




