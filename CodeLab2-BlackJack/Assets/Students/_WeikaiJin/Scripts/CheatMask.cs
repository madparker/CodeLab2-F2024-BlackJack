using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace  Weikai
{
    public class CheatMask : MonoBehaviour
    {
        private Canvas myCanvas;

        private GameObject cheatCard;
        Vector3 cheatCardPosition;
        // Start is called before the first frame update
        void Start()
        {
            myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            cheatCard = transform.GetChild(0).gameObject;
            cheatCardPosition = cheatCard.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 pos;
            // Following Mouse Position
            RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
            transform.position = myCanvas.transform.TransformPoint(pos);
            cheatCard.transform.position = cheatCardPosition;
            
            
        }
    }

}