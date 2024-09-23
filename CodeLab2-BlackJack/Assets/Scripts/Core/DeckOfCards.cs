using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DeckOfCards : MonoBehaviour {
	
	public Sprite[] cardSuits;

	//inner class that cannot exist without the main class
	public class Card{

		//an enum that holds the suits
		public enum Suit {
			SPADES, 	//0
			CLUBS,		//1
			DIAMONDS,	//2
			HEARTS	 	//3
		};

		//an enum that holds the names of the cards and their spots
		public enum Type {
			TWO		= 2,
			THREE	= 3,
			FOUR	= 4,
			FIVE	= 5,
			SIX		= 6,
			SEVEN	= 7,
			EIGHT	= 8,
			NINE	= 9,
			TEN		= 10,
			J		= 11,
			Q		= 12,
			K		= 13,
			A		= 14
		};

		public Type cardNum;
		
		public Suit suit;

		//a card returns something with a card number and a suit
		public Card(Type cardNum, Suit suit){
			this.cardNum = cardNum;
			this.suit = suit;
		}
		
		// the name of the card
		public override string ToString(){
			return "The " + cardNum + " of " + suit;
		}

		//setting the value of the high cards
		public int GetCardHighValue(){
			int val;

			switch(cardNum){
			case Type.A:
				val = 11;
				break;
			case Type.K:
			case Type.Q:
			case Type.J:
				val = 10;
				break;	
			default:
				val = (int)cardNum;
				break;
			}

			return val;
		}
	}

	//gets the deck which is a shuffle bag of cards
	public static ShuffleBag<Card> deck;

	// Use this for initialization
	void Awake () {
		
		//if the deck is not valid meaning its empty
		if(!IsValidDeck()){
			//make a new deck
			deck = new ShuffleBag<Card>();

			AddCardsToDeck();
		}

		Debug.Log("Cards in Deck: " + deck.Count);
	}

	//a deck is valid if it is not empty
	protected virtual bool IsValidDeck(){
		return deck != null; 
	}

	//go through every card in the deck and assign it a suit and number
	//there should be 52 at the end of this loop
	protected virtual void AddCardsToDeck(){
		foreach (Card.Suit suit in Card.Suit.GetValues(typeof(Card.Suit))){
			foreach (Card.Type type in Card.Type.GetValues(typeof(Card.Type))){
				deck.Add(new Card(type, suit));
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	//this function brings in the next card from the shuffle bag
	public virtual Card DrawCard(){
		Card nextCard = deck.Next();

		return nextCard;
	}


	//if the card is not a high card just return the card with its number
	//if it is a high card return it with its symbol
	public string GetNumberString(Card card){
		if(card.cardNum.GetHashCode() <= 10){
			return card.cardNum.GetHashCode() + "";
		} else {
			return card.cardNum + "";
		}
	}
		
	//get the sprite of the suit
	public Sprite GetSuitSprite(Card card){
		return cardSuits[card.suit.GetHashCode()];
	}
}
