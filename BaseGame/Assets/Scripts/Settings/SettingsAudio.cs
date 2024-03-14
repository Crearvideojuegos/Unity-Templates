using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

namespace myFPS
{
    public class SettingsAudio : MonoBehaviour
    {

        [SerializeField] private Toggle muteAllSoundToggle;
        [SerializeField] private Slider MasterSlider;
        [SerializeField] private Slider EffectsSlider;
        [SerializeField] private Slider MusicSlider;

        [SerializeField] private TextMeshProUGUI MasterTextValue;
        [SerializeField] private TextMeshProUGUI EffectsTextValue;
        [SerializeField] private TextMeshProUGUI MusicTextValue;

        [SerializeField] private AudioMixer generalMixer;
        [SerializeField] private AudioMixerGroup effectsMixerGroup;
        [SerializeField] private AudioMixerGroup musicMixerGroup;


        private void OnEnable() 
        {
            LoadUserSettings();
        }

        private void OnDisable()
        {
            LoadUserSettings();
        }

        private void Update()
        {
            generalMixer.SetFloat("MasterVolume", Mathf.Log10(MasterSlider.value) * 20);
            effectsMixerGroup.audioMixer.SetFloat("EffectsVolume", Mathf.Log10(EffectsSlider.value) * 20);
            musicMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(MusicSlider.value) * 20);

            float masterVol = MasterSlider.value * 100;
            MasterTextValue.text = masterVol.ToString("0");

            float effectsVol = EffectsSlider.value * 100;
            EffectsTextValue.text = effectsVol.ToString("0");

            float musicVol = MusicSlider.value * 100;
            MusicTextValue.text = musicVol.ToString("0");

            if(muteAllSoundToggle.isOn)
            {
                AudioListener.volume = 0;
            } else {
                AudioListener.volume = 1;
            }
        }

        public void AudioDefaultSettings()
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

        private void LoadUserSettings()
        {
            if (PlayerPrefs.GetInt(ConstantsGame.OptionMuteAllVolume) == 0)
            {
                AudioListener.volume = 1;
                muteAllSoundToggle.isOn = false;
            }
            else
            {
                AudioListener.volume = 0;
                muteAllSoundToggle.isOn = true;
            }

            MasterSlider.value = PlayerPrefs.GetFloat(ConstantsGame.OptionMasterVolume);
            EffectsSlider.value = PlayerPrefs.GetFloat(ConstantsGame.OptionEffectsVolume);
            MusicSlider.value = PlayerPrefs.GetFloat(ConstantsGame.OptionMusicVolume);

            //Text Sounds
            float masterVol = MasterSlider.value * 100;
            MasterTextValue.text = masterVol.ToString("0");

            float effectsVol = EffectsSlider.value * 100;
            EffectsTextValue.text = effectsVol.ToString("0");

            float musicVol = MusicSlider.value * 100;
            MusicTextValue.text = musicVol.ToString("0");

            //Mixers
            generalMixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat(ConstantsGame.OptionMasterVolume)) * 20);
            effectsMixerGroup.audioMixer.SetFloat("EffectsVolume", Mathf.Log10(PlayerPrefs.GetFloat(ConstantsGame.OptionEffectsVolume)) * 20);
            musicMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat(ConstantsGame.OptionMusicVolume)) * 20);

        }

        public void SaveAudioSettings()
        {
            if(muteAllSoundToggle.isOn)
            {
                PlayerPrefs.SetInt(ConstantsGame.OptionMuteAllVolume, 1);
            } else {
                PlayerPrefs.SetInt(ConstantsGame.OptionMuteAllVolume, 0);
            }

            PlayerPrefs.SetFloat(ConstantsGame.OptionMasterVolume, MasterSlider.value);
            PlayerPrefs.SetFloat(ConstantsGame.OptionEffectsVolume, EffectsSlider.value);
            PlayerPrefs.SetFloat(ConstantsGame.OptionMusicVolume, MusicSlider.value);
        }

        

    }
}

