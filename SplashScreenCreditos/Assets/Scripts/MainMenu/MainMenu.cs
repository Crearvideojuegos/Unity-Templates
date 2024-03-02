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
        [SerializeField] private GameObject mainLevelsPanel;

        private void Awake()
        {
            DefaultMainMenu();
        }

        public void DefaultMainMenu()
        {
            mainBackgroundPanel.SetActive(true);
            mainCreditsPanel.SetActive(false);
            mainLevelsPanel.SetActive(false);
        }

        public void OpenLevelsSelector()
        {
            mainBackgroundPanel.SetActive(false);
            mainLevelsPanel.SetActive(true);
        }

        public void OpenCredits()
        {
            mainBackgroundPanel.SetActive(false);
            mainCreditsPanel.SetActive(true);
        }



    }
}