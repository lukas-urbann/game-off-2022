using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singletons
{
    public class NoDestroy : MonoBehaviour
    {
        [SerializeField] private List<GameObject> dontDestroyList = new List<GameObject>();

        private void Start()
        {
            foreach (GameObject obj in dontDestroyList)
                DontDestroyOnLoad(obj);
        }
    }
}
