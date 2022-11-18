using System;
using System.Collections;
using System.Collections.Generic;
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
        private AudioSource hover;
        private AudioSource click;

        private void Start()
        {
            AudioSource[] temp = GameObject.Find("UI").GetComponents<AudioSource>();
            hover = temp[0];
            click = temp[1];
            if(text == null)
            {
                text = GetComponentInChildren(typeof(TMP_Text), true) as TMP_Text;
            }
                
            text.color = baseColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            text.color = hoverColor;
            click.Stop();
            hover.Play();
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            text.color = baseColor;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            text.color = clickColor;
            hover.Stop();
            click.Play();
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            text.color = baseColor;
        }
    }
}
