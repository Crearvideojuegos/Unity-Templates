using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace myUnityTemplate 
{
    public class LoaderScene : MonoBehaviour
    {
        public static LoaderScene Instance;

        private void Awake()
        {
            Instance = this;

            GameObject[] objs = GameObject.FindGameObjectsWithTag("LoaderScene");

            if (objs.Length > 1)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        public void LoadSceneString(string nameScene)
        {
            SceneManager.LoadScene(ConstantsGame.SceneLoadingScreen);
            StartCoroutine(LoadSceneAsync(nameScene));
        }

        private IEnumerator LoadSceneAsync(string nameScene)
        {

            yield return new WaitForSeconds(1f);
            AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);

            yield return new WaitUntil(() => operation.progress <= 0.9f);
        }


    }
}