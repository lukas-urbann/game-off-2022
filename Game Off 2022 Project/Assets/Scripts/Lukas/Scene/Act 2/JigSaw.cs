using System;
using System.Collections;
using System.Collections.Generic;
using Lukas.Interactable;
using UnityEngine;

namespace Lukas.Scene.Act2
{
    public class JigSaw : MonoBehaviour
    {
        public GameObject flint;
        public List<EnableObject> appleList = new List<EnableObject>();
        public Animator anim;

        private void Update() 
        {
            //Hele ja vím že je to dost debilní, ale upřímně jsem teď tak moc dead inside že to odmítám
            //dělat jakýmkoliv složitějším způsobem


            for (int i = 0; i < appleList.Count; i++)
            {
                if (appleList[i] == null)
                {
                    appleList.RemoveAt(i);
                    if (appleList.Count == 0)
                    {
                        anim.Play("ChairsFly");
                        flint.SetActive(true);
                    }
                }
            }
        }
    }
}
