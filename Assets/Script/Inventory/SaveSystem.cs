using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DuyBui
{
    public static class SaveSystem
    {
        private static readonly string SavePath = Application.persistentDataPath + "/gamesave.json";
        public static void SaveGame(GameData data)
        {
            try
            {
                string jsonData = JsonUtility.ToJson(data, true);
                File.WriteAllText(SavePath, jsonData);
                Debug.Log("Game Saved to: " + SavePath);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to save game: " + e.Message);
            }
        }

        public static GameData LoadGame()
        {
            if (File.Exists(SavePath))
            {
                try
                {
                    string jsonData = File.ReadAllText(SavePath);
                    GameData loadedData = JsonUtility.FromJson<GameData>(jsonData);
                    Debug.Log(loadedData.inventory.quantities[1]);

                    // Process inventory data
                    for (int i = 0; i < 9; i++)
                    {
                        if (!string.IsNullOrEmpty(loadedData.inventory.itemNames[i]))
                        {
                            Debug.Log(loadedData.inventory.itemNames[i]);

                            ItemSO item = Resources.Load<ItemSO>("Items/" + loadedData.inventory.itemNames[i]);
                            if (item != null)
                            {
                                Inventory.Instance.slots[i] = item;
                                Inventory.Instance.quantities[i] = loadedData.inventory.quantities[i];
                            }
                            else
                            {
                                Debug.LogError($"Failed to load item: {loadedData.inventory.itemNames[i]}");
                            }
                        }
                        else
                        {
                            Inventory.Instance.slots[i] = null;
                            Inventory.Instance.quantities[i] = 0;
                        }
                    }

                    return loadedData;
                }
                catch (Exception e)
                {
                    Debug.LogError("Failed to load game: " + e.Message);
                }
            }
            else
            {
                Debug.LogWarning("Save file not found at: " + SavePath);
            }

            return null;
        }

        public static void DeleteSave()
        {
            if (File.Exists(SavePath))
            {
                try
                {
                    File.Delete(SavePath);
                    Debug.Log("Save file deleted successfully");
                }
                catch (Exception e)
                {
                    Debug.LogError("Failed to delete save file: " + e.Message);
                }
            }
        }
    }
}
