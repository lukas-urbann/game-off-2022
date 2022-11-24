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
        [SerializeField]
        private Color
            baseColor = new(1, 1, 1, 1),
            hoverColor = new(0.42f, 0.8f, 0.56f, 1f),
            clickColor = new(0.9f, 0.82f, 0.16f, 1f), 
            disableColor = new(0.2f, 0.2f, 0.2f, 0.9f);

        private TMP_Text text;
        [SerializeField] private bool playSounds = true;
        private UnityEngine.UI.Button button;

        private void Start()
        {
            button = GetComponent<UnityEngine.UI.Button>();
            if (text != null)
            {
                text.color = baseColor;
            }
            else
            {
                text = GetComponentInChildren(typeof(TMP_Text), true) as TMP_Text;
            }
            if (!button.interactable)
            {
                text.color = disableColor;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!button.interactable)
            {
                return;
            }
            text.color = hoverColor;

            if (BooleanChecker.CheckSFXController() && playSounds)
            {
                SFXController.Instance.Button_PlayHover();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!button.interactable)
            {
                return;
            }
            text.color = baseColor;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!button.interactable)
            {
                return;
            }
            text.color = clickColor;

            if (BooleanChecker.CheckSFXController() && playSounds)
            {
                SFXController.Instance.Button_PlayClick();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!button.interactable)
            {
                return;
            }
            text.color = baseColor;
        }
    }
}