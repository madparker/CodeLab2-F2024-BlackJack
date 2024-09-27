using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyriFixedDealerHand : DealerHand
{
    protected override bool DealStay(int handVal){
        //if the value is 17 or over the dealer will stay and not draw another card
        return handVal >= 17;
    }
}
