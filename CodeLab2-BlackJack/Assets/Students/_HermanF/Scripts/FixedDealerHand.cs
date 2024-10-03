using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HermanF
{
    public class FixedDealerHand : DealerHand
    {
        protected override bool DealStay(int handVal)
        {
            return handVal >= 17;
        }
    }

}