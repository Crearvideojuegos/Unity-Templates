using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myUnityTemplate
{
    public class SettingsDefault : MonoBehaviour
    {
        public static SettingsDefault Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void DefaultSettings()
        {
            DefaultGraphicSettings();
        }

        public void DefaultGraphicSettings()
        {
            Application.targetFrameRate = 60;
        }
    }
}
