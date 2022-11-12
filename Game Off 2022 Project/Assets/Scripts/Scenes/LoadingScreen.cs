using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
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
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            clicheString.Add("Ask not what your country can do for you, but what you can do for your country");
            clicheString.Add("When you die, it's for a long time");
            clicheString.Add("Better to remain silent and be thought a fool that to speak and remove all doubt");
            clicheString.Add("Build a better mousetrap and the world will beat a path to your door");
            clicheString.Add("Eye of newt and toe of frog, wool of bat and tongue of dog");
            clicheString.Add("Fie, fi, foh, fum, I smell the blood of an englishman");
        }

        public void StartLoading(string sceneName)
        {
            tipOfTheDay.text = clicheString[Random.Range(0, clicheString.Count - 1)];
            StartCoroutine(PreLoadAction(sceneName));
        }
        
        private IEnumerator LoadAsynchronously(string levelName)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
            while (!operation.isDone)
            {
                Time.timeScale = 1;
                yield return null;
                loadingScreenGameObject.SetActive(false);
            }
        }

        private IEnumerator PreLoadAction(string sceneName)
        {
            loadingScreenGameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            StartCoroutine(LoadAsynchronously(sceneName));
        }
    }
}
