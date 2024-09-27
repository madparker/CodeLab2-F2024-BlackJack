using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class BlackJackHand : MonoBehaviour {

	public Text total;
	public float xOffset;
	public float yOffset;
	public GameObject handBase;
	public int handVals;

	protected DeckOfCards deck;
	protected List<DeckOfCards.Card> hand;
	bool stay = false;

	// Use this for initialization
	void Start () {
		SetupHand();
	}

	// sets up a hand by drawing two cards from a deck and putting them in the new list hand
	protected virtual void SetupHand(){
		deck = GameObject.Find("Deck").GetComponent<DeckOfCards>();
		hand = new List<DeckOfCards.Card>();
		HitMe();
		HitMe();
	}
	
	// Update is called once per frame, except in this game, because update isn't being used
	void Update () {
	}

	//function to draw a new card
	public void HitMe(){
		if(!stay){
			// if the player did not hit stay,
			// take the next card in the deck from the shuffle bag
			DeckOfCards.Card card = deck.DrawCard();
			
			// instantiate a new card
			GameObject cardObj = Instantiate(Resources.Load("prefab/Card")) as GameObject;
			
			// show the card to the player
			ShowCard(card, cardObj, hand.Count);
			
			// add it to the player's hand list
			hand.Add(card);
			
			// and call the ShowValue function
			// which will add the card's value to the total value of the player's current hand
			// and print the value on screen
			ShowValue();
		}
	}

	//takes the suit and number value of the card object that is passed into this function
	//and places a card Game Object with that information on it at a specific position on the game screen
	protected void ShowCard(DeckOfCards.Card card, GameObject cardObj, int pos){
		cardObj.name = card.ToString(); //sets the name of the cardObj game object to the name contained within the card

		cardObj.transform.SetParent(handBase.transform); //childs the cardObj to the handBase Game Object
		
		cardObj.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
		cardObj.GetComponent<RectTransform>().anchoredPosition = 
			new Vector2(
				xOffset + pos * 110, 
				yOffset);

		//sets the text of the text object childed to this cardObj to the card's type (1, 2, J, K, etc.)
		cardObj.GetComponentInChildren<Text>().text = deck.GetNumberString(card); 
		
		//sets the sprite childed to this cardObj to the sprite depicting the suit of the card
		cardObj.GetComponentsInChildren<Image>()[1].sprite = deck.GetSuitSprite(card);
	}

	//prints the value of the player's hand on the screen
	protected virtual void ShowValue(){
		
	}

	//gets the manager script
	//and returns the integer returned by the GetHandValue function within the BlackJackManager script
	public int GetHandValue(){
		BlackJackManager manager = GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>();

		return manager.GetHandValue(hand);
	}
}
