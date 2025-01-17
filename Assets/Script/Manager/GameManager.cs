using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


namespace DuyBui
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get => instance; }
        private static GameManager instance;
        private GameObject player;
        private int currentLevel;

        public bool LoadMode { get => loadMode; }
        private bool loadMode;

        private Dictionary<string, int> dict = new Dictionary<string, int>();
        private string currentScene;

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
        }
        // Start is called before the first frame update
        private void InitLevel()
        {
            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlayBGM("game-music-loop-7-145285");
            }

            player = GameObject.FindGameObjectWithTag("Player");


            MenuManager.Instance.SetMenuState(MenuManager.MenuState.InGame);

        }

        public string LoadLevel()
        {
            GameData loadedData = SaveSystem.LoadGame();

            if (loadedData == null)
            {
                return "Level1";
            }
            currentLevel = loadedData.currentLevel;
            loadMode = true;
            return (dict.FirstOrDefault(x => x.Value == currentLevel).Key);

        }

        public void Load()
        {
            GameData loadedData = SaveSystem.LoadGame();

            if (loadedData == null)
            {
                return;
            }
            InitLevel();
        }


        private void OnApplicationQuit()
        {
            Save();
        }

        private void Save()
        {
            GameData gameData = new GameData(Inventory.Instance, currentLevel);
            SaveSystem.SaveGame(gameData);
        }
    }
}
