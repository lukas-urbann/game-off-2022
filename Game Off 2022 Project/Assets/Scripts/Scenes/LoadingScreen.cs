using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Scenes
{
    public class LoadingScreen : MonoBehaviour
    {
        public static LoadingScreen Instance;
        [SerializeField] private GameObject loadingScreenGameObject;
        [SerializeField] private TMP_Text tipOfTheDay;
        [SerializeField] private List<String> clicheString = new List<string>();
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
            
            AddCliches("Ask not what your country can do for you, but what you can do for your country");
            AddCliches("Better to remain silent and be thought a fool that to speak and remove all doubt");
            AddCliches("Build a better mousetrap and the world will beat a path to your door");
            AddCliches("Eye of newt and toe of frog, wool of bat and tongue of dog");
            AddCliches("Fie, fi, foh, fum, I smell the blood of an englishman");
        }

        public void StartLoading(string sceneName)
        {
            ChooseTip();
            StartCoroutine(PreLoadAction(sceneName));
        }

        private void ChooseTip()
        {
            tipOfTheDay.text = clicheString[Random.Range(0, clicheString.Count - 1)];
        }
        
        private IEnumerator LoadAsynchronously(string levelName)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
            while (!operation.isDone)
            {
                Time.timeScale = 1;
                yield return null;
                SetActiveStates(false);
            }
        }

        private IEnumerator PreLoadAction(string sceneName)
        {
            SetActiveStates(true);
            yield return new WaitForSeconds(3f);
            StartCoroutine(LoadAsynchronously(sceneName));
        }

        private void SetActiveStates(bool status)
        {
            loadingScreenGameObject.SetActive(status);
        }

        private void AddCliches(string cliche)
        {
            clicheString.Add(cliche);
        }
    }
}
