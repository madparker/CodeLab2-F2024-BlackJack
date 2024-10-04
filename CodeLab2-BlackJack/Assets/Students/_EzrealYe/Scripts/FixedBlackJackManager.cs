using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EzrealYe {
    public class FixedBlackJackManager : BlackJackManager
    {
        public int playerChips = 100;  // initial player chips
        public int dealerChips = 100;  // initial dealer chips
        public int betAmount = 10;     // default bet amount for each round
        public Text playerChipText;    // UI element for displaying player's chips
        public Text dealerChipText;    // UI element for displaying dealer's chips
        public Button allInButton;     // button for All-In action
        private bool isAllIn = false;  // track if All-In is activated

        void Start()
        {
            UpdateChipsUI();  // initialize chips display
            allInButton.onClick.AddListener(HandleAllIn);  // bind All-In button click event so I don't have to do it again in inspector
        }

        // method to handle All-In action when button is clicked
        private void HandleAllIn()
        {
            betAmount = playerChips;  // set the bet amount to all of the player's chips
            isAllIn = true;  // mark that All-In is activated
        }

        // override original function
        public override void PlayerWin()
        {
            if (isAllIn)
            {
                playerChips += betAmount * 2;  // If all-In, player wins double the chips
            }
            else
            {
                playerChips += betAmount;  // regular win adds the bet amount to player's chips
            }

            dealerChips -= betAmount;  // deduct bet amount from dealer's chips
            UpdateChipsUI();  // update the chips display
            base.PlayerWin();  // call the original PlayerWin logic
            ResetBet();  // reset bet amount and All-In status
        }

        // override original function
        public override void PlayerLose()
        {
            playerChips -= betAmount;  // Deduct the bet amount from player's chips
            dealerChips += betAmount;  // Add the bet amount to dealer's chips
            UpdateChipsUI();  // Update the chips display
            base.PlayerLose();  // Call the original PlayerLose logic

            ResetBet();  // Reset bet amount and All-In status
        }

        // override original function
        public override void DealerBusted()
        {
            if (isAllIn)
            {
                playerChips += betAmount * 2;  // if All-In, player wins double the chips
            }
            else
            {
                playerChips += betAmount;  // regular win adds the bet amount to player's chips
            }

            dealerChips -= betAmount;  // deduct bet amount from dealer's chips
            UpdateChipsUI();  // update the chips display
            base.DealerBusted();  // call the original DealerBusted logic

            ResetBet();  // reset bet amount and All-In status
        }

        // override original function
        public override void PlayerBusted()
        {
            playerChips -= betAmount;  // deduct the bet amount from player's chips
            dealerChips += betAmount;  // add the bet amount to dealer's chips
            UpdateChipsUI();  // update the chips display
            base.PlayerBusted();  // call the original PlayerBusted logic

            ResetBet();  // reset bet amount and All-In status
        }

        // Update the chip UI display 
        void UpdateChipsUI()
        {
            if (playerChipText != null)
            {
                playerChipText.text = "Player Chips: " + playerChips;  // update player's chips text
            }

            if (dealerChipText != null)
            {
                dealerChipText.text = "Dealer Chips: " + dealerChips;  // update dealer's chips text
            }

            // disable the All-In button if the player has no chips left
            if (playerChips <= 0)
            {
                allInButton.interactable = false;  // Disable the All-In button
            }
            else
            {
                allInButton.interactable = true;  // Enable the All-In button
            }
        }

        // reset the bet amount and All-In status
        void ResetBet()
        {
            betAmount = 10;  // Restore default bet amount
            isAllIn = false;  // Reset All-In status
        }

        // Override TryAgain method to reset game without resetting chips
        public override void TryAgain()
        {
            UpdateChipsUI();  // update chips display
            base.TryAgain();  // call the original scene reloading logic
        }
    }
}


