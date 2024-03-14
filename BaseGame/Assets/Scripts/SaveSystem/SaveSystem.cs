using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace myFPS 
{
    public class SaveSystem : MonoBehaviour
    {
        public static SaveSystem Instance;
        PlayerProfile playerProfile;
        private string saveFilePath;

        private void Awake() 
        {
            Instance = this;

            GameObject[] objs = GameObject.FindGameObjectsWithTag("SaveSystem");
            if (objs.Length > 1)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);

            playerProfile = new PlayerProfile();
            saveFilePath = Application.persistentDataPath + "/playerProfile.json";

            LoadGame();
        }

        public void LoadGame()
        {
            if(File.Exists(saveFilePath))
            {
                string loadPlayerData = File.ReadAllText(saveFilePath);
                playerProfile = JsonUtility.FromJson<PlayerProfile>(loadPlayerData);
            }
        }

        public void SaveGame()
        {
            string savePlayerData = JsonUtility.ToJson(playerProfile);
            File.WriteAllText(saveFilePath, savePlayerData);
        }

        public void CreateProfileFirstTime()
        {
            playerProfile = new PlayerProfile();
            if(!playerProfile.profileCreated)
            {
                playerProfile.profileCreated = true;
                SaveGame();
            }
        }

        public bool ProfileHasCreated()
        {
            if(playerProfile.playerName == "" || playerProfile.playerName is null )
            {
                return false;
            } else {
                return true;
            }
        }

        public PlayerProfile Profile()
        {
            return playerProfile;
        }

        public void SavePlayerName(string name)
        {
            string loadPlayerData = File.ReadAllText(saveFilePath);
            playerProfile = JsonUtility.FromJson<PlayerProfile>(loadPlayerData);
            playerProfile.playerName = name;
            SaveGame();
        }




    }
}
