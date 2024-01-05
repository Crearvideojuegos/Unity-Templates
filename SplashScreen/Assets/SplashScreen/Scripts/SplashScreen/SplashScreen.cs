using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace nameSplashScreen
{
    public class SplashScreen : MonoBehaviour
    {
        [SerializeField] private Image myLogo;
        [SerializeField] private GameObject loadingImage;
        private bool loadFinish;
        private bool endLogo;

        public static SplashScreen Instance;

        private void Awake() 
        {
            Instance = this;
        }

        private void Start()
        {
            loadingImage.SetActive(false);
            loadFinish = false;
            endLogo = false;
            myLogo.color = new Color(myLogo.color.r, myLogo.color.g, myLogo.color.b, 0f);

            #if UNITY_EDITOR
                PlayerPrefs.DeleteAll();
            #endif

            if (PlayerPrefs.GetInt("FirstTimeOpenGame") == 0)
            {
                //Default Settings
                SettingsDefault.Instance.DefaultSettings();

                //Finish
                PlayerPrefs.SetInt("FirstTimeOpenGame", 1);
            }

            loadFinish = true;
        }

        private void Update() 
        {
            if(loadFinish && endLogo)
            {
                // SceneManager.LoadScene("MainMenu");
            }
        }

        public void EndLogoAnimation()
        {
            endLogo = true;
            StartCoroutine(LoadLoadingImage());
        }

        private IEnumerator LoadLoadingImage()
        {
            yield return new WaitForSeconds(1f);
            loadingImage.SetActive(true);
        }

    }
}
