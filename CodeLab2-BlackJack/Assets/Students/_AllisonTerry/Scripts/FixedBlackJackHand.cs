using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AllisonTerry
{
    public class FixedBlackJackHand : BlackJackHand
    {

        protected override void SetupHand()
        {
            base.SetupHand();
            if(handVals == 21){
                GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().BlackJack();
            }
        }
    }
}

