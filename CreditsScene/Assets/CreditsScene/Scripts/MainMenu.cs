using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace nameCreditsScene
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject mainBackgroundPanel;
        [SerializeField] private GameObject mainCreditsPanel;

        public void DefaultMainMenu()
        {
            mainBackgroundPanel.SetActive(true);
            mainCreditsPanel.SetActive(false);
        }

        public void OpenCredits()
        {
            mainBackgroundPanel.SetActive(false);
            mainCreditsPanel.SetActive(true);
        }

        public void CloseMainMenu()
        {
            mainBackgroundPanel.SetActive(false);
            mainCreditsPanel.SetActive(false);
        }



    }
}