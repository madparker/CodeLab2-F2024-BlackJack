using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BlackJackManager : MonoBehaviour {

	public Text statusText;
	public GameObject tryAgain;
	public string loadScene;

	public void PlayerBusted(){
		//game over for the player busting
		HidePlayerButtons();
		GameOverText("YOU BUST", Color.red);
	}

	public void DealerBusted(){
		//game over text and color for the dealer losing
		GameOverText("DEALER BUSTS!", Color.green);
	}
		
	public void PlayerWin(){
		//game over text for winning
		GameOverText("YOU WIN!", Color.green);
	}
		
	public void PlayerLose(){
		//game over text for losing
		GameOverText("YOU LOSE.", Color.red);
	}


	public void BlackJack(){
		//sets the game over text to win and the color to green
		GameOverText("Black Jack!", Color.green);
		//then hides the hit and stay buttons
		HidePlayerButtons();
	}

	//displays the game over text and sets the try again button to be on
	public void GameOverText(string str, Color color){
		statusText.text = str;
		statusText.color = color;

		tryAgain.SetActive(true);
	}

	//hides the buttons hti and stay
	public void HidePlayerButtons(){
		GameObject.Find("HitButton").SetActive(false);
		GameObject.Find("StayButton").SetActive(false);
	}

	//try again button reloads the scene
	public void TryAgain(){
		SceneManager.LoadScene(loadScene);
	}

	//adds all the cards together to get the hand value
	public virtual int GetHandValue(List<DeckOfCards.Card> hand){
		int handValue = 0;

		foreach(DeckOfCards.Card handCard in hand){
			handValue += handCard.GetCardHighValue();
		}
		return handValue;
	}
}
