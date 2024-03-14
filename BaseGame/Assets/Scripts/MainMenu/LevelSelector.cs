using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace myFPS
{
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] private GameObject mainLevelsPanel;
        [SerializeField] private GameObject mainCreateProfilePanel;
        [SerializeField] private TMP_Text TextNamePlayer;
        [SerializeField] private TMP_InputField InputNamePlayer;

        private void Awake() 
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
        private void Start()
        {
            if(SaveSystem.Instance.ProfileHasCreated())
            {
                OpenLevelsSelector();
            } else {
                OpenChangeProfile();
            }
            var profile = SaveSystem.Instance.Profile();
            TextNamePlayer.text = profile.playerName;
            InputNamePlayer.text = profile.playerName;

            //Validation
            InputNamePlayer.characterValidation = TMP_InputField.CharacterValidation.Alphanumeric;
            InputNamePlayer.characterLimit = 14;
            InputNamePlayer.onValidateInput += ValidateInput;
        }

        private char ValidateInput(string text, int charIndex, char addedChar)
        {
            if (char.IsLetterOrDigit(addedChar))
            {
                return addedChar;
            }
            else
            {
                return '\0';
            }
        }

        public void SaveNameProfile()
        {
            TextNamePlayer.text = InputNamePlayer.text;
            SaveSystem.Instance.SavePlayerName(InputNamePlayer.text);
            OpenLevelsSelector();
        }

        public void OpenLevelsSelector()
        {
            mainCreateProfilePanel.SetActive(false);
            mainLevelsPanel.SetActive(true);
        }

        public void OpenChangeProfile()
        {
            var profile = SaveSystem.Instance.Profile();
            InputNamePlayer.text = profile.playerName;
            mainCreateProfilePanel.SetActive(true);
            mainLevelsPanel.SetActive(false);
        }

    }
}

