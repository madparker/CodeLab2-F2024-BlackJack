namespace Utility
{
    public abstract class GameEventArgs
    {
        
    }
    
    public class OnBankRollChangedEventArgs : GameEventArgs
    {
        public int From { get; }
        public int To { get; }
        
        public OnBankRollChangedEventArgs(int from, int to)
        {
            From = from;
            To = to;
        }
    }
    
    public class OnPlayerSplitCardEventArgs : GameEventArgs
    {

    }
    
    public class OnSplitEnableEventArgs : GameEventArgs
    {

    }
    
    public class OnPlayerHitEventArgs : GameEventArgs
    {
        public bool IsDoubleDown { get; }
        
        public OnPlayerHitEventArgs(bool isDoubleDown)
        {
            IsDoubleDown = isDoubleDown;
        }
    }
    
    public class OnStartButtonClickedEventArgs : GameEventArgs
    {

    }
    
    public class OnPlayerStayEventArgs : GameEventArgs
    {

    }
    
    public class OnPlayerPlaceBetEventArgs : GameEventArgs
    {
        public int BetAmount { get; }
        
        public OnPlayerPlaceBetEventArgs(int betAmount)
        {
            BetAmount = betAmount;
        }
    }
    
    public class OnPotSizeChangedEventArgs : GameEventArgs
    {
        public int From { get; }
        public int To { get; }
        
        public OnPotSizeChangedEventArgs(int from, int to)
        {
            From = from;
            To = to;
        }
    }
    
    public class OnGameEndEventArgs : GameEventArgs
    {
        public bool IsPlayerWin { get; }
        
        public OnGameEndEventArgs(bool isPlayerWin)
        {
            IsPlayerWin = isPlayerWin;
        }
    }
    
    public class OnSceneLoadedEventArgs : GameEventArgs
    {
        
    }
    
    
}