using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AllisonTerry
{
    public class FixedDealerHand : DealerHand
    {

        protected override bool DealStay(int handVal)
        {
            return handVal >= 17;
        }
    }

}