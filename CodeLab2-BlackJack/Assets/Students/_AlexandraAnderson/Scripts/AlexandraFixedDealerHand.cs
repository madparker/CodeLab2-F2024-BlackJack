using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexandraAnderson
{
    public class AlexandraFixedDealerHand : DealerHand
    {
        protected virtual bool DealStay(int handVal){
            //if the value is over 17 the dealer will stay and not draw another card
		
            return handVal >= 17;
        }

        public void ResetHand()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            
        }
        
    }
}

