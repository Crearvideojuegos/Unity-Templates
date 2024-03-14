using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace myFPS
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
            Cursor.lockState = CursorLockMode.Locked;
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
                //Default Options
                SettingsStartGame.Instance.OpenFirstTimeGame();
                PlayerPrefs.SetInt(ConstantsGame.FirstTimeOpenGame, 1);
            }

            SaveSystem.Instance.CreateProfileFirstTime();
        
            SettingsStartGame.Instance.AfterPlayed();

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
