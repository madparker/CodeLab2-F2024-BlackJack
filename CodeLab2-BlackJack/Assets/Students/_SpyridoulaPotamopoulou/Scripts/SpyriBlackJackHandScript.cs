using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyriBlackJackHandScript : BlackJackHand
{
    private int initialScore = 0;

    protected override void ShowValue()
    {
        base.ShowValue();
        if (handVals == 21)
        {
            GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().PlayerWin();
        }

        Debug.Log(handVals);
    }

    /*
    void AutoWinCheck()
    {
        initialScore = GetHandValue();
        if (initialScore == 21)
        {
            GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().PlayerWin();
        }
    }
    */
}
