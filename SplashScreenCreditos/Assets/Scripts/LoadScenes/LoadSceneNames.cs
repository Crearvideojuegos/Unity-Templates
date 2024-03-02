using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myFPS 
{
    public class LoadSceneNames : MonoBehaviour
    {
        public static LoadSceneNames Instance;

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
            LoaderScene.Instance.LoadSceneString(ConstantsGame.SceneTestLevel);
        }

        public void SceneMainMenu()
        {
            LoaderScene.Instance.LoadSceneString(ConstantsGame.SceneMainMenu);
        }

        public void QuitGame()
        {
            Application.Quit();
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}