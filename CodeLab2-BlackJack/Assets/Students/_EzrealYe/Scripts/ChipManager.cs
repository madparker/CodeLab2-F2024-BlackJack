using UnityEngine;
using UnityEngine.UI;

public class ChipManager : MonoBehaviour
{
    public BlackJackManager blackJackManager; // 引用原来的 BlackJackManager
    public int playerChips = 100;             // 初始玩家筹码
    public int dealerChips = 100;             // 初始庄家筹码
    public Text playerChipText;               // 用于显示玩家筹码的 UI
    public Text dealerChipText;               // 用于显示庄家筹码的 UI
    public int betAmount = 10;                // 默认赌注金额

    void Start()
    {
        UpdateChipsUI();
    }

    public void PlayerWin()
    {
        // 玩家赢，增加筹码
        playerChips += betAmount;
        dealerChips -= betAmount;
        UpdateChipsUI();
        
        // 调用原始 BlackJackManager 的玩家胜利逻辑
        blackJackManager.PlayerWin();
    }

    public void PlayerLose()
    {
        // 玩家输，减少筹码
        playerChips -= betAmount;
        dealerChips += betAmount;
        UpdateChipsUI();
        
        // 调用原始 BlackJackManager 的玩家失败逻辑
        blackJackManager.PlayerLose();
    }

    // 更新 UI 显示
    void UpdateChipsUI()
    {
        playerChipText.text = "Player Chips: " + playerChips;
        dealerChipText.text = "Dealer Chips: " + dealerChips;
    }
}