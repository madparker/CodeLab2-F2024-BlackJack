using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BlackJackManager : MonoBehaviour {

	public Text statusText;
	public GameObject tryAgain;
	public string loadScene;
	

	//initiates a game over condition for if the player busts
	//meaning their hand value is greater than 21
	public void PlayerBusted(){
		HidePlayerButtons(); //hides the buttons on screen to prevent the player from making any more moves
		GameOverText("YOU BUST", Color.red); //feeds the relevant text and color into the GameOverText function
	}

	//initiates a game over condition for if the dealer busts
	//meaning the dealer's hand value is greater than 21
	public void DealerBusted(){
		GameOverText("DEALER BUSTS!", Color.green); //feeds the relevant text and color into the GameOverText function
		HidePlayerButtons(); //hides the buttons on screen to prevent the player from making any more moves
	}
		
	//initiates a game over condition for if the player wins
	//meaning their hand value is closer to 21 than the dealer's, but no one has busted
	public void PlayerWin(){
		GameOverText("YOU WIN!", Color.green); //feeds the relevant text and color into the GameOverText function
		HidePlayerButtons(); //hides the buttons on screen to prevent the player from making any more moves
	}
		
	//initiates a game over condition for if the player loses
	//meaning the dealer's hand value is closer to 21 than the player's, but no one has busted
	public void PlayerLose(){
		GameOverText("YOU LOSE.", Color.red); //feeds the relevant text and color into the GameOverText function
		HidePlayerButtons(); //hides the buttons on screen to prevent the player from making any more moves
	}


	public void BlackJack(){
		//sets the game over text to win and the color of the text to green
		GameOverText("Black Jack!", Color.green);
		//then hides the hit and stay buttons
		HidePlayerButtons();
	}

	//displays the game over text on screen and sets the try again button to be on
	public void GameOverText(string str, Color color){
		statusText.text = str;
		statusText.color = color;

		tryAgain.SetActive(true);
	}

	//hides the buttons which allow the player to hit or stay
	public void HidePlayerButtons(){
		if (GameObject.Find("HitButton") != null && GameObject.Find("StayButton") != null)
		{
			GameObject.Find("HitButton").SetActive(false);
			GameObject.Find("StayButton").SetActive(false);
		}
		
		
	}

	//a function which, when called, reloads the scene and starts the game over
	public void TryAgain(){
		SceneManager.LoadScene(loadScene);
	}

	//adds all the cards in a specific hand together to get the hand's value
	public virtual int GetHandValue(List<DeckOfCards.Card> hand){
		int handValue = 0;

		foreach(DeckOfCards.Card handCard in hand){
			handValue += handCard.GetCardHighValue();
		}
		return handValue;
	}
}
