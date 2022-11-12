using System;
using Game.Utility;
using Singletons;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
    public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Color
            baseColor = new Color(1, 1, 1, 1),
            hoverColor = new Color(0.42f, 0.8f, 0.56f, 1),
            clickColor = new Color(0.9f,0.82f,0.16f, 1);
        
        [SerializeField] private TMP_Text text;
        [SerializeField] private bool playSounds = true;

        private void Start()
        {
            if(text != null)
                text.color = baseColor;
            else
                text = GetComponentInChildren(typeof(TMP_Text), true) as TMP_Text;
            
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            text.color = hoverColor;

            if (BooleanChecker.CheckSFXController() && playSounds)
                SFXController.Instance.Button_PlayHover();
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            text.color = baseColor;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            text.color = clickColor;
            
            if (BooleanChecker.CheckSFXController() && playSounds)
                SFXController.Instance.Button_PlayClick();
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            text.color = baseColor;
        }
    }
}
