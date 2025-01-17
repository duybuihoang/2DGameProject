using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;


namespace DuyBui
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance { get => instance; }
        private static GameManager instance;

        private GameObject player;
        private int currentLevel = 1;



        public bool LoadMode { get; private set; }


        private Dictionary<string, int> dict = new Dictionary<string, int>();
        private string previousSceneName;
        private string currentSceneName;

        private void Awake()
        {

            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);

            dict.Add("Level1", 1);
            dict.Add("Level2", 2);
            dict.Add("Level3", 3);

            currentSceneName = SceneManager.GetActiveScene().name;
            previousSceneName = "";

            SceneManager.activeSceneChanged += OnActiveSceneChanged;

        }
        // Start is called before the first frame update
        private void InitLevel()
        {
            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlayBGM("game-music-loop-7-145285");
            }

            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log(player);


            MenuManager.Instance.SetMenuState(MenuManager.MenuState.InGame);
            

            if (LoadMode)
            {
                GameData loadedData = SaveSystem.LoadGame();

            }
        }

        public string LoadGame()
        {
            //Inventory.Instance.ClearInventory();

            GameData loadedData = SaveSystem.LoadGame();
            if (loadedData == null)
            {
                Debug.Log("No save file found. Starting new game...");
                return "Level1";
            }

            LoadMode = true;
            currentLevel = loadedData.currentLevel;

            return dict.FirstOrDefault(x => x.Value == currentLevel).Key;

        }

        private void OnActiveSceneChanged(Scene previousScene, Scene newScene)
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            Debug.Log($"Scene changed from {previousScene.name} to {newScene.name}");
            currentSceneName = newScene.name;
            Debug.Log(currentLevel);




            if (previousSceneName == "Menu" && currentSceneName.Contains("Level"))
            {
                InitLevel();
            }


            previousSceneName = currentSceneName;

        }

        private void OnApplicationQuit()
        {
            Save();
        }

        public void Save()
        {
            Debug.Log(Inventory.Instance);
            GameData gameData = new GameData(Inventory.Instance, currentLevel);
            SaveSystem.SaveGame(gameData);
        }
    }
}
