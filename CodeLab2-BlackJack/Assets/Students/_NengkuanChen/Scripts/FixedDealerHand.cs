namespace Students._NengkuanChen.Scripts
{
    public class FixedDealerHand : DealerHand
    {
        protected override bool DealStay(int handVal)
        {
            return handVal >= 17;
        }
    }
}