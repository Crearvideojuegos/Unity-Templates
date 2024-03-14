using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace myFPS
{
    public class SettingsVideo : MonoBehaviour
    {
        [SerializeField] private Toggle fullScreenToggle;
        [SerializeField] private Toggle vSyncToggle;
        [SerializeField] private TMP_Dropdown resolutionMenu;
        [SerializeField] private TMP_Dropdown LimitFPS;

        private void OnEnable() 
        {
            LoadUserSettings();
            SetDropdownChangeResolution();
            SetDropdownChangeLimitFPS();
            SetToggleVSync();
            SetToggleFullScreen();
        }

        private void OnDisable()
        {
            LoadUserSettings();
        }

        private void SetDropdownChangeResolution()
        {
            resolutionMenu.onValueChanged.AddListener(ChangeResolution);
        }

        private void SetDropdownChangeLimitFPS()
        {
            LimitFPS.onValueChanged.AddListener(ChangeLimitFPS);
        }

        private void SetToggleVSync()
        {
            vSyncToggle.onValueChanged.AddListener(ChangeVSync);
        }

        private void SetToggleFullScreen()
        {
            fullScreenToggle.onValueChanged.AddListener(ChangeFullScreen);
        }


        public void DefaultVideoSettings()
        {
            QualitySettings.vSyncCount = 0;
            ChangeResolution(1);
            ChangeVSync(false);
            ChangeFullScreen(true);

            PlayerPrefs.SetInt(ConstantsGame.OptionLimitFPS, 0);
            PlayerPrefs.SetInt(ConstantsGame.OptionResolution, 1);
            PlayerPrefs.SetInt(ConstantsGame.OptionFullScreen, 1);
            PlayerPrefs.SetInt(ConstantsGame.OptionVSync, 0);
        }

        public void LoadUserSettings()
        {
            //fullScreenToggle.isOn
            if (PlayerPrefs.GetInt(ConstantsGame.OptionFullScreen) == 0)
            {
                fullScreenToggle.isOn = false;
            }
            else
            {
                fullScreenToggle.isOn = true;
            }

            //vSync
            if (PlayerPrefs.GetInt(ConstantsGame.OptionVSync) == 0)
            {
                vSyncToggle.isOn = false;
            }
            else
            {
                vSyncToggle.isOn = true;
            }

            //Resolution
            resolutionMenu.value = PlayerPrefs.GetInt(ConstantsGame.OptionResolution);
            if (PlayerPrefs.GetInt(ConstantsGame.OptionResolution) != resolutionMenu.value)
            {
                ChangeResolution(resolutionMenu.value);
            }

            //Limit FPS
            LimitFPS.value = PlayerPrefs.GetInt(ConstantsGame.OptionLimitFPS);
            if (PlayerPrefs.GetInt(ConstantsGame.OptionLimitFPS) != LimitFPS.value)
            {
                ChangeLimitFPS(LimitFPS.value);
            }
        }

        public void SaveVideoSettings()
        {
            PlayerPrefs.SetInt(ConstantsGame.OptionLimitFPS, LimitFPS.value);
            PlayerPrefs.SetInt(ConstantsGame.OptionResolution, resolutionMenu.value);

            if(fullScreenToggle.isOn) {
                PlayerPrefs.SetInt(ConstantsGame.OptionFullScreen, 1);
            } else {
                PlayerPrefs.SetInt(ConstantsGame.OptionFullScreen, 0);
            }

            if(vSyncToggle.isOn) {
                PlayerPrefs.SetInt(ConstantsGame.OptionVSync, 1);
            } else {
                PlayerPrefs.SetInt(ConstantsGame.OptionVSync, 0);
            }

            ChangeResolution(resolutionMenu.value);
            ChangeLimitFPS(LimitFPS.value);
            ChangeVSync(vSyncToggle.isOn);
        }

        private void ChangeResolution(int resolutionOption)
        {
            if (resolutionOption == 0)
            {
                Screen.SetResolution(2560, 1440, fullScreenToggle.isOn);
            }
            else if (resolutionOption == 1)
            {
                Screen.SetResolution(1920, 1080, fullScreenToggle.isOn);
            }
            else if (resolutionOption == 2)
            {
                Screen.SetResolution(1366, 768, fullScreenToggle.isOn);
            }
            else if (resolutionOption == 3)
            {
                Screen.SetResolution(1280, 800, fullScreenToggle.isOn);
            }
        }

        private void ChangeLimitFPS(int LimitFPSOption)
        {
            if (LimitFPSOption == 0)
            {
                Application.targetFrameRate = 60;
            }
            else if (LimitFPSOption == 1)
            {
                Application.targetFrameRate = 100;
            }
            else if (LimitFPSOption == 2)
            {
                Application.targetFrameRate = 144;
            }
            else if (LimitFPSOption == 3)
            {
                Application.targetFrameRate = -1;
            }
        }

        private void ChangeVSync(bool vSync)
        {
            if(vSync)
            {
                QualitySettings.vSyncCount = 1;
            } else {
                QualitySettings.vSyncCount = 0;
            }
        }

        private void ChangeFullScreen(bool fullScreen)
        {
            Screen.fullScreen = fullScreen;
        }



    }
}