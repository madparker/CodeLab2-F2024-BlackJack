using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //singleton setup
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Header("Game Status")]
    public int playerHealth = 100;
    public int dealerHealth = 100;

    public bool damageable = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerHealth -= 10;
        }

        if (damageable)
        {
            DealDamage();
            damageable = false;
        }
        
        Debug.Log("Player Health: " + playerHealth);
        Debug.Log("Dealer Health: " + dealerHealth);

    }

    public void RestartGame()
    {
        playerHealth = 100;
        dealerHealth = 100;
    }

    public void DamagePlayer(int damage)
    {
        playerHealth -= damage;
    }

    public void DamageDealer(int damage)
    {
        dealerHealth -= damage;
    }
    
    public void DealDamage()
    {
        BlackJackHand playerHand = GameObject.Find("Player Hand Value").GetComponent<BlackJackHand>();
        DealerHand dealerHand = GameObject.Find("Dealer Hand Value").GetComponent<DealerHand>();

        //if the dealer's hand value is less than the player's hand value
        if(dealerHand.handVals < playerHand.handVals){
            DamageDealer(playerHand.handVals - dealerHand.handVals);
						
            // if the dealer's hand value is higher
        } else {
            DamagePlayer(dealerHand.handVals - playerHand.handVals);
        }
            
        //bust damage to both sides
        if (dealerHand.handVals > 21)
        {
            GameManager.instance.DamageDealer(10);
        }

        if (playerHand.handVals > 21)
        {
            GameManager.instance.DamagePlayer(10);
        }
    }
}
