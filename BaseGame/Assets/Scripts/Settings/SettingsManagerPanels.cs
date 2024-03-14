using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace myFPS
{
    public class SettingsManagerPanels : MonoBehaviour
    {
        //Panels
        [SerializeField] private GameObject videoPanel;
        [SerializeField] private GameObject audioPanel;
        [SerializeField] private GameObject controlsPanel;

        //Buttons
        [SerializeField] private Button btnVideo;
        [SerializeField] private Button btnAudio;
        [SerializeField] private Button btnControls;


        private void OnEnable() 
        {
            OpenVideoPanel();
        }

        public void OpenVideoPanel()
        {
            btnVideo.image.color = new Color(0.85f, 0.90f, 0.45f, 1f);
            btnAudio.image.color = new Color(1f, 1f, 1f, 1f);
            btnControls.image.color = new Color(1f, 1f, 1f, 1f);

            videoPanel.SetActive(true);
            audioPanel.SetActive(false);
            controlsPanel.SetActive(false);
        }

        public void OpenAudioPanel()
        {
            btnVideo.image.color = new Color(1f, 1f, 1f, 1f);
            btnAudio.image.color = new Color(0.85f, 0.90f, 0.45f, 1f);
            btnControls.image.color = new Color(1f, 1f, 1f, 1f);

            videoPanel.SetActive(false);
            audioPanel.SetActive(true);
            controlsPanel.SetActive(false);
        }

        public void OpenControlsPanel()
        {
            btnVideo.image.color = new Color(1f, 1f, 1f, 1f);
            btnAudio.image.color = new Color(1f, 1f, 1f, 1f);
            btnControls.image.color = new Color(0.85f, 0.90f, 0.45f, 1f);

            videoPanel.SetActive(false);
            audioPanel.SetActive(false);
            controlsPanel.SetActive(true);
        }

    }
}