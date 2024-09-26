using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AllisonTerry
{
    public class FixedBlackJackHand : BlackJackHand
    {

        protected override void ShowValue()
        {
            base.ShowValue();
            if(handVals == 21){
                GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().BlackJack();
            }
        }
    }
}

