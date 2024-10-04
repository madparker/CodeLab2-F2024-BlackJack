using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpyriPotam;

public class SpyriFixedDealerHand : DealerHand
{
    public Text cheatingText;
    public SingletonManagementScript cheatRecorder;
    
    protected override bool DealStay(int handVal){
        //if the value is 17 or over the dealer will stay and not draw another card
        return handVal >= 17;
    }

    //A function that allows the player a chance to see what the dealer's hidden card is
    public void playerCheats()
    {
        GameObject hiddenCard = transform.GetChild(0).gameObject;
        int myNumber = Random.Range(1, 5);
        Debug.Log("My number is " + myNumber);
        
        //if the player has never cheated successfully, or they failed to cheat in the last round,
        //AND they have not yet tried to cheat this round,
        //they have an 80% chance of cheating successfully
        if (cheatRecorder.timesCheated == 0 && cheatRecorder.haveCheated == false)
        {
            //if they have cheated successfully, text on screen prints the dealer's hidden card's name
            //then the timesCheated int is incremented by 1
            //then the cheat button is deactivated
            //and last, the haveCheated bool is set to true to prevent the later "ifs" from running
            //as that would throw an error where the game tries to hide the cheat button which is already null
            if (myNumber <= 4)
            {
                cheatingText.text = "(The Dealer has " + hiddenCard.name + ")";
                cheatRecorder.IncrementCheatCount();
                Debug.Log("I cheated " + cheatRecorder.timesCheated);
                GameObject.Find("Cheat").SetActive(false);
                cheatRecorder.haveCheated = true;
            }
            
            //if the player has failed to cheat, a game over condition is initiated informing them
            //they were caught. The successful cheat counter is reset.
            else
            {
                SpyriBlackJackManager spyrisManager = GameObject.Find("BlackJackManager").GetComponent<SpyriBlackJackManager>();
                spyrisManager.PlayerCaughtCheating();
                GameObject.Find("Cheat").SetActive(false);
                cheatRecorder.timesCheated = 0;
                cheatRecorder.haveCheated = true;
            }
        }
        
        //if the player has successfully cheated one time in a row, the player has a 60% chance 
        //of cheating successfully
        if (cheatRecorder.timesCheated == 1 && cheatRecorder.haveCheated == false)
        {
            //debug message
            Debug.Log("HI IM RUNNING");
            if (myNumber <= 3)
            {
                cheatingText.text = "(The Dealer has " + hiddenCard.name + ")";
                cheatRecorder.IncrementCheatCount();
                Debug.Log("I cheated " + cheatRecorder.timesCheated);
                GameObject.Find("Cheat").SetActive(false);
                cheatRecorder.haveCheated = true;
            }
            else
            {
                SpyriBlackJackManager spyrisManager = GameObject.Find("BlackJackManager").GetComponent<SpyriBlackJackManager>();
                spyrisManager.PlayerCaughtCheating();
                GameObject.Find("Cheat").SetActive(false);
                cheatRecorder.timesCheated = 0;
                cheatRecorder.haveCheated = true;
            }
        }
        
        //if the player has successfully cheated twice in a row, they have a 40% chance of cheating successfully
        if (cheatRecorder.timesCheated == 2 && cheatRecorder.haveCheated == false)
        {
            if (myNumber <= 2)
            {
                cheatingText.text = "(The Dealer has " + hiddenCard.name + ")";
                cheatRecorder.IncrementCheatCount();
                Debug.Log("I cheated " + cheatRecorder.timesCheated);
                GameObject.Find("Cheat").SetActive(false);
                cheatRecorder.haveCheated = true;
            }
            else
            {
                SpyriBlackJackManager spyrisManager = GameObject.Find("BlackJackManager").GetComponent<SpyriBlackJackManager>();
                spyrisManager.PlayerCaughtCheating();
                GameObject.Find("Cheat").SetActive(false);
                cheatRecorder.timesCheated = 0;
                cheatRecorder.haveCheated = true;
            }
        }
        
        //if the player has successfully cheated thrice in a row, they have a 20% chance of cheating successfully
        if (cheatRecorder.timesCheated == 3 && cheatRecorder.haveCheated == false)
        {
            if (myNumber <= 1)
            {
                cheatingText.text = "(The Dealer has " + hiddenCard.name + ")";
                cheatRecorder.IncrementCheatCount();
                Debug.Log("I cheated " + cheatRecorder.timesCheated);
                GameObject.Find("Cheat").SetActive(false);
                cheatRecorder.haveCheated = true;
            }
            else
            {
                SpyriBlackJackManager spyrisManager = GameObject.Find("BlackJackManager").GetComponent<SpyriBlackJackManager>();
                spyrisManager.PlayerCaughtCheating();
                GameObject.Find("Cheat").SetActive(false);
                cheatRecorder.timesCheated = 0;
                cheatRecorder.haveCheated = true;
            }
        }
        
        //if the player has successfully cheated 4 times, they fail automatically upon cheating
        if (cheatRecorder.timesCheated >= 4 && cheatRecorder.haveCheated == false)
        {
            SpyriBlackJackManager spyrisManager = GameObject.Find("BlackJackManager").GetComponent<SpyriBlackJackManager>();
            spyrisManager.PlayerCaughtCheating();
            cheatRecorder.timesCheated = 0;
            GameObject.Find("Cheat").SetActive(false);
            cheatRecorder.haveCheated = true;
        }
        
    }
}
