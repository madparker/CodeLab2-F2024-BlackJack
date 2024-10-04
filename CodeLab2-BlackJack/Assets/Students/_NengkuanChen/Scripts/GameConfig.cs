using UnityEngine;
using UnityEngine.Serialization;

namespace Students._NengkuanChen.Scripts
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [FormerlySerializedAs("startingBankRoll")] [SerializeField]
        private int startingBankroll = 1000;
        
        public int StartingBankroll => startingBankroll;
        
        [SerializeField]
        private int minBet = 10;
        
        public int MinBet => minBet;
        
        [SerializeField]
        private int maxBet = 500;
        
        public int MaxBet => maxBet;
        
        
    }
}