using System;
using System.Collections.Generic;
using Utility;

namespace Students._NengkuanChen.Scripts
{
    public class FixedBlackJackManager : BlackJackManager
    {
        private void Awake()
        {
            EventUtility.TriggerNow(typeof(OnSceneLoadedEventArgs), new OnSceneLoadedEventArgs());
        }

        public override void PlayerBusted()
        {
            base.PlayerBusted();
            EventUtility.TriggerNow(this, new OnGameEndEventArgs(false));
        }

        public override void PlayerLose()
        {
            base.PlayerLose();
            EventUtility.TriggerNow(this, new OnGameEndEventArgs(false));
        }
        
        public override void PlayerWin()
        {
            base.PlayerWin();
            EventUtility.TriggerNow(this, new OnGameEndEventArgs(true));
        }
        
        public override void DealerBusted()
        {
            base.DealerBusted();
            EventUtility.TriggerNow(this, new OnGameEndEventArgs(true));
        }

        public override int GetHandValue(List<DeckOfCards.Card> hand)
        {
            var handVal = 0;
            var aceCount = 0;
            foreach (var card in hand)
            {
                if (card.cardNum == DeckOfCards.Card.Type.A)
                {
                    aceCount++;
                }

                handVal += card.GetCardHighValue();
            }
            
            while (handVal > 21 && aceCount > 0)
            {
                handVal -= 10;
                aceCount--;
            }
            
            return handVal;
        }
    }
}