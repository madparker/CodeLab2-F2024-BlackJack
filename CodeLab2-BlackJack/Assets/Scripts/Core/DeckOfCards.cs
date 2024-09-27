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
			Spades, 	//0
			Clubs,		//1
			Diamonds,	//2
			Hearts	 	//3
		};

		//an enum that holds the names of the cards and their spots
		public enum Type {
			Two		= 2,
			Three	= 3,
			Four	= 4,
			Five	= 5,
			Six		= 6,
			Seven	= 7,
			Eight	= 8,
			Nine	= 9,
			Ten		= 10,
			J		= 11,
			Q		= 12,
			K		= 13,
			A		= 14
		};

		public Type cardNum;
		
		public Suit suit;

		//this function returns a Card object, which comes with a card number and a suit
		public Card(Type cardNum, Suit suit){
			this.cardNum = cardNum;
			this.suit = suit;
		}
		
		// the name of the card
		public override string ToString(){
			return "The " + cardNum + " of " + suit;
		}

		//returns the highest possible value of each card type
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

	//declares the deck variable, which is a shuffle bag of cards
	public static ShuffleBag<Card> deck;

	// Use this for initialization
	void Awake () {
		
		//if the deck is not valid, meaning its empty/null
		if(!IsValidDeck()){
			//make a new deck
			deck = new ShuffleBag<Card>();

			//calls this function to initialize every card in the deck
			AddCardsToDeck();
		}

		Debug.Log("Cards in Deck: " + deck.Count);
	}

	//returns true if a deck is valid, meaning it is not empty
	protected virtual bool IsValidDeck(){
		return deck != null; 
	}

	//go through every card in the deck and assign it a unique combination of suit and number
	//there should be 52 unique cards at the end of this loop
	protected virtual void AddCardsToDeck(){
		foreach (Card.Suit suit in Card.Suit.GetValues(typeof(Card.Suit))){
			foreach (Card.Type type in Card.Type.GetValues(typeof(Card.Type))){
				deck.Add(new Card(type, suit));
			}
		}
	}

	//this function returns the next card from the shuffle bag
	public virtual Card DrawCard(){
		Card nextCard = deck.Next();

		return nextCard;
	}


	//if the card is not a face card (J, Q, K, A) returns the card's hashcode (which is equal to its type)
	//if it is a face card, return it with its symbol
	public string GetNumberString(Card card){
		if(card.cardNum.GetHashCode() <= 10){
			return card.cardNum.GetHashCode() + "";
		} else {
			return card.cardNum + "";
		}
	}
		
	//returns the sprite of the suit of the card passed into this function
	public Sprite GetSuitSprite(Card card){
		return cardSuits[card.suit.GetHashCode()];
	}
}
