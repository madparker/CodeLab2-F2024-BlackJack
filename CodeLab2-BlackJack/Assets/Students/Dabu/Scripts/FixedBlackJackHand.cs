using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DabuLyu
{
    public class FixedBlackJackHand : BlackJackHand
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        protected override void ShowValue()
        {
            //base.ShowValue();
            handVals = GetComponent<FixedBlackJackManager>().BlackJackGetHandValue(hand);
			
            total.text = "Player: " + handVals;

            if(handVals > 21){
                GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().PlayerBusted();
            }
            
        }
    }

}
