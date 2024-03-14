using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace myFPS
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject mainBackgroundPanel;
        [SerializeField] private GameObject mainCreditsPanel;
        [SerializeField] private GameObject mainSettingsPanel;

        private void Awake()
        {
            DefaultMainMenu();
            Cursor.lockState = CursorLockMode.None;
        }

        public void DefaultMainMenu()
        {
            mainBackgroundPanel.SetActive(true);
            mainCreditsPanel.SetActive(false);
            mainSettingsPanel.SetActive(false);
        }

        public void OpenCredits()
        {
            mainBackgroundPanel.SetActive(false);
            mainCreditsPanel.SetActive(true);
        }

        public void OpenSettings()
        {
            mainBackgroundPanel.SetActive(false);
            mainSettingsPanel.SetActive(true);
        }




    }
}