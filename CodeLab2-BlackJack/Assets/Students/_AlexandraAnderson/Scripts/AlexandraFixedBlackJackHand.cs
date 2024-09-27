using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexandraAnderson
{
    
    public class AlexandraFixedBlackJackHand : BlackJackHand
    {
        public void ResetHand()
        {
            SetupHand();
        }
        protected override void SetupHand()
        {
          
            for ( int i =0; i < transform.childCount; i++) {Destroy(transform.GetChild(i).gameObject);
                
            }

            //if (tester == 0)
            //{
            //    Debug.Log("transform.ChildCount: " + transform.childCount);
            //}
            
            
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

