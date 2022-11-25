using System;
using System.Collections;
using System.Collections.Generic;
using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lukas.Scene
{
    public class CompleteAct : MonoBehaviour
    {
        public static Lukas.Scene.CompleteAct Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        public static void EnterNextLevel()
        {
            LoadingScreen.Instance.StartLoading(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        public static void EnterNextLevel(string levelName)
        {
            LoadingScreen.Instance.StartLoading(levelName);
        }
    }
}
