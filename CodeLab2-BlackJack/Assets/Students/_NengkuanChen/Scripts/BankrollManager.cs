using UnityEngine;
using Utility;

namespace Students._NengkuanChen.Scripts
{
    public static class BankrollManager
    {
        public static int Bankroll { get; private set; } = GameSetting.StartingBankRoll;

        public static int PotSize { get; private set; } = 0;
        
        public static bool CanDoubleDown => Bankroll >= PotSize;

        static BankrollManager()
        {
            EventUtility.Subscribe(typeof(OnPlayerPlaceBetEventArgs), OnPlayerPlaceBet);
            EventUtility.Subscribe(typeof(OnSceneLoadedEventArgs), OnSceneLoaded);
            EventUtility.Subscribe(typeof(OnGameEndEventArgs), OnGameEnd);
        }

        private static void OnGameEnd(object sender, GameEventArgs args)
        {
            var gameEndArgs = (OnGameEndEventArgs) args;
            if (gameEndArgs.IsPlayerWin)
            {
                ChangeBankroll(Bankroll +  2 * PotSize);
            }
        }

        private static void OnSceneLoaded(object sender, GameEventArgs args)
        {
            //Set up initial PotSize
            PotSize = 0;
            ChangePot(GameSetting.MinBet);
        }
        
        public static void ChangePot(int changeAmount)
        {
            if (changeAmount > 0)
            {
                AddToPot(changeAmount);
            }
            else
            {
                SubtractFromPot(-changeAmount);
            }
        }
        
        public static void DoubleDown()
        {
            ChangeBankroll(Bankroll - PotSize);
            EventUtility.TriggerNow(null, new OnPotSizeChangedEventArgs(PotSize, PotSize * 2));
            PotSize *= 2;
        }
        
        
        public static void AddToPot(int amount)
        {
            amount = Mathf.Min(amount, Bankroll);
            var targetPotSize = Mathf.Min(PotSize + amount, GameSetting.MaxBet);
            var resultChange = targetPotSize - PotSize;
            ChangeBankroll(Bankroll - resultChange);
            EventUtility.TriggerNow(null, new OnPotSizeChangedEventArgs(PotSize, targetPotSize));
            PotSize = targetPotSize;
        }
        
        public static void SubtractFromPot(int amount)
        {
            if (PotSize <= GameSetting.MinBet)
            {
                return;
            }
            amount = Mathf.Min(amount, PotSize - GameSetting.MinBet);
            var targetPotSize = Mathf.Max(PotSize - amount, GameSetting.MinBet);
            var resultChange = PotSize - targetPotSize;
            ChangeBankroll(Bankroll + resultChange);
            EventUtility.TriggerNow(null, new OnPotSizeChangedEventArgs(PotSize, targetPotSize));
            PotSize = targetPotSize;
        }
        
        

        private static void OnPlayerPlaceBet(object sender, GameEventArgs args)
        {
            var betAmount = ((OnPlayerPlaceBetEventArgs) args).BetAmount;
            ChangePot(betAmount);
        }
        
        public static void ChangeBankroll(int amount)
        {
            EventUtility.TriggerNow(null, new OnBankRollChangedEventArgs(Bankroll, amount));
            Bankroll = amount;
        }
    }
}