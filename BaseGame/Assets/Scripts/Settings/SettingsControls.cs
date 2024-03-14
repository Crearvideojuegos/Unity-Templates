using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace myFPS
{
    public class SettingsControls : MonoBehaviour
    {

        [SerializeField] private Slider XHorizontalSlider;
        [SerializeField] private Slider YVerticalSlider;

        [SerializeField] private TextMeshProUGUI XHorizontalTextValue;
        [SerializeField] private TextMeshProUGUI YVerticalTextValue;

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
            float XHorizontal = XHorizontalSlider.value * 100;
            XHorizontalTextValue.text = XHorizontal.ToString("0");

            float YVertical = YVerticalSlider.value * 100;
            YVerticalTextValue.text = YVertical.ToString("0");
        }

        public void ControlsDefaultSettings()
        {
            PlayerPrefs.SetFloat(ConstantsGame.MouseHorizontalX, 0.5f);
            PlayerPrefs.SetFloat(ConstantsGame.MouseVerticalY, 0.5f);
        }

        private void LoadUserSettings()
        {
            XHorizontalSlider.value = PlayerPrefs.GetFloat(ConstantsGame.MouseHorizontalX);
            YVerticalSlider.value = PlayerPrefs.GetFloat(ConstantsGame.MouseVerticalY);

            float XHorizontal = XHorizontalSlider.value * 100;
            XHorizontalTextValue.text = XHorizontal.ToString("0");

            float YVertical = YVerticalSlider.value * 100;
            YVerticalTextValue.text = YVertical.ToString("0");
        }

        public void SaveControlsSettings()
        {
            PlayerPrefs.SetFloat(ConstantsGame.MouseHorizontalX, XHorizontalSlider.value);
            PlayerPrefs.SetFloat(ConstantsGame.MouseVerticalY, YVerticalSlider.value);
        }

    }
}