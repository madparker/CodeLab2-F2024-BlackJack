using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DabuLyu
{
    public class SelectableCard : MonoBehaviour,IPointerClickHandler
    {
        
        private RectTransform rectTransform;
        private bool isSelected = false;
        //private Vector2 originalPosition;
        
        public float moveDistance = 20f;
        
        private FixedBlackJackHand hand;
        public DeckOfCards.Card card;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            //originalPosition = rectTransform.anchoredPosition;
            hand = GetComponentInParent<FixedBlackJackHand>();
            int cardIndex = transform.GetSiblingIndex();
            if (cardIndex < hand.GetHand().Count)
            {
                card = hand.GetHand()[cardIndex];
            }
            
        }

        public void OnPointerClick(PointerEventData eventData)
        {
  
            if (isSelected)
            {
                rectTransform.anchoredPosition += new Vector2(0, -moveDistance);
                isSelected = false;
                hand.selectedCardIndex--;
                hand.clearCheckCards.Remove(card);
                hand.clearCheckCardObjs.Remove(gameObject);
                
                
            }
            else if (hand.selectedCardIndex < 2)
            {
                rectTransform.anchoredPosition += new Vector2(0, moveDistance);
                isSelected = true;
                hand.selectedCardIndex++;
                hand.clearCheckCards.Add(card);
                hand.clearCheckCardObjs.Add(gameObject);

                if (hand.selectedCardIndex == 2)
                {
                    hand.ClearPairCheck();
                }
            }
        }
        

    }

}
