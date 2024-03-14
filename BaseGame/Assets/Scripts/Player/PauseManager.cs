using System.Collections;
using System.Collections.Generic;
using myFPS;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButtons;
    public GameObject pauseSettings;

    public static PauseManager Instance;

    private void Awake() 
    {
        Instance = this;
        pausePanel.SetActive(false);
        pauseButtons.SetActive(false);
        pauseSettings.SetActive(false);
    }

    public void PauseMenu()
    {
        PlayerInput.Instance.PauseGame();
    }

    public void OpenSettings()
    {
        pauseButtons.SetActive(false);
        pauseSettings.SetActive(true);
    }

    public void ReturnPauseMenu()
    {
        pauseButtons.SetActive(true);
        pauseSettings.SetActive(false);
    }

}
