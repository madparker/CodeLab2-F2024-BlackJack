using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyriBlackJackHandScript : BlackJackHand
{
    private bool playerHasHit = false;
    
    protected override void SetupHand()
    {
        //sets up the player's hand
        base.SetupHand();
        
        //checks if the value of the player's hand is 21 at the time of this check (the start of the game)
        //since the HitMe function called within SetupHand calls the ShowValue function at its end, you do not
        //need to call ShowValue here to get the value of the player's hand- it has already been calculated!
        if (handVals == 21)
        {
            //if yes, initiates the game over condition indicating the player has won and gotten a BlackJack
            GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().BlackJack();
        }

        //prints the handVals to the console integer for testing purposes
        Debug.Log(handVals);
    }
    
    
    //my original solution to the autowin, which is more complicated than it needed to be but which still works
    
    /*
    protected override void ShowValue()
    {
        //runs the original showValue function to get the value of the player's hand
        base.ShowValue();
        
        //if the value of the player's hand is 21 and they have not yet hit (i.e. it is the start of the game)
        if (handVals == 21 && playerHasHit == false)
        {
            Debug.Log(playerHasHit);
            //initiate the game over condition indicating the player has won and gotten an automatic BlackJack
            GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().BlackJack();
        }

        //prints the handVals to the console integer for testing purposes
        Debug.Log(handVals);
    } 
    
    //checks if the player has pressed the hit button 
    //must be put into the Hit button in the inspector to work
    public void HitCheck()
    {
        playerHasHit = true;
    }*/

}
