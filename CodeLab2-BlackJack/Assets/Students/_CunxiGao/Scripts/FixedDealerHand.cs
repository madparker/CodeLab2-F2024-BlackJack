using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CunxiGao
{
    public class FixedDealerHand : DealerHand
    {
        protected override bool DealStay(int handVal)
        {
            //if the value is over 17 the dealer will stay and not draw another card
            return handVal >= 17;
        }
    }
}
