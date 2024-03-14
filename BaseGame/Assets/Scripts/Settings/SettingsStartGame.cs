using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;


namespace myFPS
{

    public class SettingsStartGame : MonoBehaviour
    {
        public static SettingsStartGame Instance;

        [SerializeField] private AudioMixer generalMixer;
        [SerializeField] private AudioMixerGroup effectsMixerGroup;
        [SerializeField] private AudioMixerGroup musicMixerGroup;

        private void Awake() 
        {
            Instance = this;
        }

        public void OpenFirstTimeGame()
        {
            DefaultVideoSettings();
            DefaultAudioSettings();
            DefaultControlsSettings();
        }

        private void DefaultVideoSettings()
        {
            Application.targetFrameRate = 60;
            Screen.SetResolution(1920, 1080, true);
            QualitySettings.vSyncCount = 0;
            Screen.fullScreen = true;

            PlayerPrefs.SetInt(ConstantsGame.OptionLimitFPS, 0);
            PlayerPrefs.SetInt(ConstantsGame.OptionResolution, 1);
            PlayerPrefs.SetInt(ConstantsGame.OptionFullScreen, 1);
            PlayerPrefs.SetInt(ConstantsGame.OptionVSync, 0);

        }

        private void DefaultAudioSettings()
        {
            AudioListener.volume = 1;

            generalMixer.SetFloat("MasterVolume", Mathf.Log10(0.75f) * 20);
            effectsMixerGroup.audioMixer.SetFloat("EffectsVolume", Mathf.Log10(0.75f) * 20);
            musicMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(0.75f) * 20);

            PlayerPrefs.SetInt(ConstantsGame.OptionMuteAllVolume, 0);
            PlayerPrefs.SetFloat(ConstantsGame.OptionMasterVolume, 0.75f);
            PlayerPrefs.SetFloat(ConstantsGame.OptionEffectsVolume, 0.75f);
            PlayerPrefs.SetFloat(ConstantsGame.OptionMusicVolume, 0.75f);
        }

        private void DefaultControlsSettings()
        {
            PlayerPrefs.SetFloat(ConstantsGame.MouseHorizontalX, 0.5f);
            PlayerPrefs.SetFloat(ConstantsGame.MouseVerticalY, 0.5f);
        }

        public void AfterPlayed()
        {
            VideoSettings();
            AudioSettings();
            ControlSettings();
        }

        private void VideoSettings()
        {
            int optionResolution = PlayerPrefs.GetInt(ConstantsGame.OptionResolution);
            bool boolOptionRes = true;
            
            int optionVSync = PlayerPrefs.GetInt(ConstantsGame.OptionVSync);
            bool boolOptionVSync = true;

            if(optionResolution == 0) { boolOptionRes = false; }
            if(optionVSync == 0) { boolOptionVSync = false; }


            int resolutionOption = PlayerPrefs.GetInt(ConstantsGame.OptionLimitFPS);
            if (resolutionOption == 0)
            {
                Screen.SetResolution(2560, 1440, boolOptionRes);
            }
            else if (resolutionOption == 1)
            {
                Screen.SetResolution(1920, 1080, boolOptionRes);
            }
            else if (resolutionOption == 2)
            {
                Screen.SetResolution(1366, 768, boolOptionRes);
            }
            else if (resolutionOption == 3)
            {
                Screen.SetResolution(1280, 800, boolOptionRes);
            }

            if(boolOptionVSync)
            {
                QualitySettings.vSyncCount = 1;
            } else {
                QualitySettings.vSyncCount = 0;
            }

            int limitFPSOption = PlayerPrefs.GetInt(ConstantsGame.OptionLimitFPS);

            if (limitFPSOption == 0)
            {
                Application.targetFrameRate = 60;
            }
            else if (limitFPSOption == 1)
            {
                Application.targetFrameRate = 100;
            }
            else if (limitFPSOption == 2)
            {
                Application.targetFrameRate = 144;
            }
            else if (limitFPSOption == 3)
            {
                Application.targetFrameRate = -1;
            }

            Screen.fullScreen = boolOptionRes;

        }

        private void AudioSettings()
        {
            if(PlayerPrefs.GetInt(ConstantsGame.OptionMuteAllVolume) == 0)
            {
                AudioListener.volume = 1;

            } else {
                AudioListener.volume = 0;
            }

            generalMixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat(ConstantsGame.OptionMasterVolume)) * 20);
            effectsMixerGroup.audioMixer.SetFloat("EffectsVolume", Mathf.Log10(PlayerPrefs.GetFloat(ConstantsGame.OptionEffectsVolume)) * 20);
            musicMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat(ConstantsGame.OptionMusicVolume)) * 20);
        }

        private void ControlSettings()
        {
            //Future controls if you need
        }


    }
}
