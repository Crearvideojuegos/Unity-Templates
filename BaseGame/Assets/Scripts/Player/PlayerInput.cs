using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace myFPS
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerControls playerControls; //Input System
        private PlayerPause playerPause; //Input System

        private CharacterController characterController;
        private float mouseSensitivityX;
        private float mouseSensitivityY;
        private float xRotation;
        public Transform camTrans;
        public Vector2 moveInput; //WASD Movement
        private Vector3 moveData;
        public Vector2 LookInput; //Mouse Look Movement
        private bool gameIsPaused;
        public static PlayerInput Instance;

        private void Awake() 
        {
            Instance = this;
            playerControls = new PlayerControls();
            playerPause = new PlayerPause();
            characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            gameIsPaused = true;
        }

        private void OnEnable() 
        {
            mouseSensitivityX = PlayerPrefs.GetFloat(ConstantsGame.MouseHorizontalX);
            mouseSensitivityY = PlayerPrefs.GetFloat(ConstantsGame.MouseVerticalY);
        }

        private void Start()
        {
            playerControls.Enable();
            playerPause.Enable();
            playerPause.PauseInAc.Pause.performed += ctx => PauseGame();
        }

        private void Update()
        {
            CaptureInput();
        }

        private void FixedUpdate() 
        {
            MoveCharacter();
            Look();
        }

        private void CaptureInput()
        {
            moveInput = playerControls.PlayerInAc.Move.ReadValue<Vector2>();
            LookInput = playerControls.PlayerInAc.Look.ReadValue<Vector2>();
        }

        private void MoveCharacter()
        {
            Vector3 vertMove = transform.forward * moveInput.y;
            Vector3 horiMove = transform.right * moveInput.x;
            moveData = horiMove + vertMove;
            moveData.Normalize();
            moveData = moveData * 5f;
            characterController.Move(moveData * Time.fixedDeltaTime);
        }

        private void Look()
        {
            Vector2 mouseInput = new Vector2(LookInput.x * mouseSensitivityX, LookInput.y * mouseSensitivityY);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

            xRotation -= mouseInput.y;
            xRotation = xRotation = Mathf.Clamp(xRotation, -65f, 65f);
            camTrans.localRotation = Quaternion.Euler(xRotation, 0, 0);
        }

        public void PauseGame()
        {
            if(gameIsPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                playerControls.Disable();
                PauseManager.Instance.pausePanel.SetActive(true);
                PauseManager.Instance.pauseButtons.SetActive(true);

                gameIsPaused = false;
            } else {
                RechargeControlsOptions();
                Cursor.lockState = CursorLockMode.Locked;
                playerControls.Enable();
                PauseManager.Instance.pausePanel.SetActive(false);
                PauseManager.Instance.pauseButtons.SetActive(false);
                gameIsPaused = true;
            }
        }

        private void RechargeControlsOptions()
        {
            mouseSensitivityX = PlayerPrefs.GetFloat(ConstantsGame.MouseHorizontalX);
            mouseSensitivityY = PlayerPrefs.GetFloat(ConstantsGame.MouseVerticalY);
        }

        private void OnDisable() 
        {
            playerPause.Disable();
            playerControls.Disable();
        }


    }
}

