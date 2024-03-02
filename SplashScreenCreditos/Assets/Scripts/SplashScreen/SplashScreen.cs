using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace myUnityTemplate
{
    public class SplashScreen : MonoBehaviour
    {
        [SerializeField] private Image myLogo;
        private bool loadFinish;
        private bool endLogo;
        public static SplashScreen Instance;

        private void Awake() 
        {
            Instance = this;
        }

        private void Start()
        {
            loadFinish = false;
            endLogo = false;
            myLogo.color = new Color(myLogo.color.r, myLogo.color.g, myLogo.color.b, 0f);

            #if UNITY_EDITOR
                PlayerPrefs.DeleteAll();
            #endif

            if (PlayerPrefs.GetInt(ConstantsGame.FirstTimeOpenGame) == 0)
            {
                //Default Settings
                SettingsDefault.Instance.DefaultSettings();

                //Finish
                PlayerPrefs.SetInt(ConstantsGame.FirstTimeOpenGame, 1);
            }

            loadFinish = true;
        }

        private void Update() 
        {
            if(loadFinish && endLogo)
            {
                LoaderScene.Instance.LoadSceneString(ConstantsGame.SceneMainMenu);
            }
        }

        public void EndLogoAnimation()
        {
            endLogo = true;
        }

    }
}
