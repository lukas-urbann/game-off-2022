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
               
            if (tipOfTheDay == null)
            {
                tipOfTheDay = GameObject.Find("Tip").GetComponent<TMP_Text>();
            }
            if (loadingScreenGameObject == null)
            {
                loadingScreenGameObject = GameObject.Find("Loading Screen");
                loadingScreenGameObject.SetActive(false);
            }

            clicheString.Add("Ask not what your country can do for you, but what you can do for your country");
            clicheString.Add("When you die, it's for a long time");
            clicheString.Add("Better to remain silent and be thought a fool that to speak and remove all doubt");
            clicheString.Add("Build a better mousetrap and the world will beat a path to your door");
            clicheString.Add("Eye of newt and toe of frog, wool of bat and tongue of dog");
            clicheString.Add("Fie, fi, foh, fum, I smell the blood of an englishman");
        }

        private void Start()
        {
            Time.timeScale = 1;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public void StartLoading(string sceneName)
        {
            tipOfTheDay.text = clicheString[Random.Range(0, clicheString.Count - 1)];
            StartCoroutine(PreLoadAction(sceneName));
        }
        public void StartLoading(int sceneInt)
        {
            tipOfTheDay.text = clicheString[Random.Range(0, clicheString.Count - 1)];
            StartCoroutine(PreLoadAction(NameFromIndex(sceneInt)));
        }

        private IEnumerator LoadAsynchronously(string levelName)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
            while (!operation.isDone)
            {
                Time.timeScale = 1;
                yield return null;
            }
        }

        private IEnumerator PreLoadAction(string sceneName)
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            loadingScreenGameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            StartCoroutine(LoadAsynchronously(sceneName));
        }

        private static string NameFromIndex(int BuildIndex)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
            int slash = path.LastIndexOf('/');
            string name = path.Substring(slash + 1);
            int dot = name.LastIndexOf('.');
            return name.Substring(0, dot);
        }
    }
}
