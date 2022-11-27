using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lukas.Player
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory Instance;
        private List<string> items = new List<string>();

        private void Awake()
        {
            if (Instance != this && Instance != null)
                Destroy(gameObject);
            else
                Instance = this;
        }

        public void AddItem(string item)
        {
            items.Add(item);
        }

        public void RemoveItem(string item)
        {
            for(int i = 0; i < items.Count; i++)
                if (items[i].Equals(item))
                    items.RemoveAt(i);
        }
        
        public bool CheckItem(string item)
        {
            for(int i = 0; i < items.Count; i++)
                if (items[i].Equals(item))
                    return true;

            return false;
        }
    }
}
