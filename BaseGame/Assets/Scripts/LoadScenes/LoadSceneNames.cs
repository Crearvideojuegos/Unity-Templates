using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myFPS 
{
    public class LoadSceneNames : MonoBehaviour
    {
        public static LoadSceneNames Instance;
        [SerializeField] private AudioSource audioSource;
        private float timeToWaitSound = 0.5f;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("LoaderScene");

            if (objs.Length == 0)
            {
                GameObject LoaderScene = new GameObject("LoaderScene");
                LoaderScene.AddComponent<LoaderScene>();
            }
        }

        public void SceneTestLevel()
        {
            SoundButtonLoadScene();
            StartCoroutine(CoroutineSceneTestLevel());
        }

        private IEnumerator CoroutineSceneTestLevel()
        {
            yield return new WaitForSeconds(timeToWaitSound);
            LoaderScene.Instance.LoadSceneString(ConstantsGame.SceneTestLevel);
        }

        public void SceneMainMenu()
        {
            SoundButtonLoadScene();
            StartCoroutine(CoroutineSceneMainMenu());
        }

        private IEnumerator CoroutineSceneMainMenu()
        {
            yield return new WaitForSeconds(timeToWaitSound);
            LoaderScene.Instance.LoadSceneString(ConstantsGame.SceneMainMenu);
        }

        public void SceneLevelSelector()
        {
            SoundButtonLoadScene();
            StartCoroutine(CoroutineLevelSelector());
        }

        private IEnumerator CoroutineLevelSelector()
        {
            yield return new WaitForSeconds(timeToWaitSound);
            LoaderScene.Instance.LoadSceneString(ConstantsGame.SceneLevelSelector);

        }

        public void QuitGame()
        {
            Application.Quit();
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }

        private void SoundButtonLoadScene()
        {
            audioSource.Play();
        }



    }
}