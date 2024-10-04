using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VivianChen
{
    public class VivianFixedBlackJackHand : BlackJackHand
    {
        protected override void SetupHand()
        {
            base.SetupHand();
            
            // Natural Black Jack: If player starts with 21, player automatically wins
            if (handVals == 21)
            {
                Debug.Log("Natural Black Jack");
                
                GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().BlackJack();
                
            }
        }
    }
}
