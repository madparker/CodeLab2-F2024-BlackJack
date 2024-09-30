using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpyriFixedDealerHand : DealerHand
{
    public Text cheatingText;
    public SingletonManagementScript cheatRecorder;
    
    protected override bool DealStay(int handVal){
        //if the value is 17 or over the dealer will stay and not draw another card
        return handVal >= 17;
    }

    public void playerCheats()
    {
        GameObject hiddenCard = transform.GetChild(0).gameObject;
        int myNumber = Random.Range(1, 5);
        Debug.Log(myNumber);
        
        if (cheatRecorder.timesCheated == 0)
        {
            if (myNumber <= 4)
            {
                cheatingText.text = "(The Dealer has " + hiddenCard.name + ")";
                cheatRecorder.timesCheated += 1;
                GameObject.Find("Cheat").SetActive(false);
            }
            else
            {
                SpyriBlackJackManager spyrisManager = GameObject.Find("BlackJackManager").GetComponent<SpyriBlackJackManager>();
                spyrisManager.PlayerCaughtCheating();
                GameObject.Find("Cheat").SetActive(false);
                cheatRecorder.timesCheated = 0;
            }
        }
        
        else if (cheatRecorder.timesCheated == 1)
        {
            if (myNumber <= 3)
            {
                cheatingText.text = "(The Dealer has " + hiddenCard.name + ")";
                cheatRecorder.timesCheated += 1;
                GameObject.Find("Cheat").SetActive(false);
            }
            else
            {
                SpyriBlackJackManager spyrisManager = GameObject.Find("BlackJackManager").GetComponent<SpyriBlackJackManager>();
                spyrisManager.PlayerCaughtCheating();
                GameObject.Find("Cheat").SetActive(false);
                cheatRecorder.timesCheated = 0;
            }
        }
        
        else if (cheatRecorder.timesCheated == 2)
        {
            if (myNumber <= 2)
            {
                cheatingText.text = "(The Dealer has " + hiddenCard.name + ")";
                cheatRecorder.timesCheated += 1;
                GameObject.Find("Cheat").SetActive(false);
            }
            else
            {
                SpyriBlackJackManager spyrisManager = GameObject.Find("BlackJackManager").GetComponent<SpyriBlackJackManager>();
                spyrisManager.PlayerCaughtCheating();
                GameObject.Find("Cheat").SetActive(false);
                cheatRecorder.timesCheated = 0;
            }
        }
        
        else if (cheatRecorder.timesCheated == 3)
        {
            if (myNumber <= 1)
            {
                cheatingText.text = "(The Dealer has " + hiddenCard.name + ")";
                cheatRecorder.timesCheated += 1;
                GameObject.Find("Cheat").SetActive(false);
            }
            else
            {
                SpyriBlackJackManager spyrisManager = GameObject.Find("BlackJackManager").GetComponent<SpyriBlackJackManager>();
                spyrisManager.PlayerCaughtCheating();
                GameObject.Find("Cheat").SetActive(false);
                cheatRecorder.timesCheated = 0;
            }
        }

        else if (cheatRecorder.timesCheated >= 4)
        {
            SpyriBlackJackManager spyrisManager = GameObject.Find("BlackJackManager").GetComponent<SpyriBlackJackManager>();
            spyrisManager.PlayerCaughtCheating();
            cheatRecorder.timesCheated = 0;
            GameObject.Find("Cheat").SetActive(false);
        }
        
    }
}
