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
	
	// Update is called once per frame
	void Update () {
	}

	//function to draw  anew card
	public void HitMe(){
		if(!stay){
			// if the player did not hit stay
			//take the next card in the deck from the shuffle bag
			DeckOfCards.Card card = deck.DrawCard();
			
			// instantiate a new card
			GameObject cardObj = Instantiate(Resources.Load("prefab/Card")) as GameObject;
			
			// show the card
			ShowCard(card, cardObj, hand.Count);
			//add it to the hand list
			hand.Add(card);
			
			//add it to the total value
			ShowValue();
		}
	}

	//sets  the cards to a specific position and shows the sprites and number
	protected void ShowCard(DeckOfCards.Card card, GameObject cardObj, int pos){
		cardObj.name = card.ToString();

		cardObj.transform.SetParent(handBase.transform);
		cardObj.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
		cardObj.GetComponent<RectTransform>().anchoredPosition = 
			new Vector2(
				xOffset + pos * 110, 
				yOffset);

		cardObj.GetComponentInChildren<Text>().text = deck.GetNumberString(card);
		cardObj.GetComponentsInChildren<Image>()[1].sprite = deck.GetSuitSprite(card);
	}

	//gets the value of the player hand
	protected virtual void ShowValue(){
		//gets the total value
		handVals = GetHandValue();
		
		//shows the value			
		total.text = "Player: " + handVals;

		//if the hand is over 21 the player busts
		if(handVals > 21){
			GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().PlayerBusted();
		}
	}

	//gets the manager script and returns get hand value
	public int GetHandValue(){
		BlackJackManager manager = GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>();

		return manager.GetHandValue(hand);
	}
}
