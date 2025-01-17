
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    [System.Serializable]
    public class GameData
    {

        public SerializableInventory inventory;
        public int currentLevel;
        public Dictionary<string, bool> levelCompletion;
        public Vector3 playerPosition;

        public GameData(Inventory inventory, int level)
        {
            this.inventory = new SerializableInventory(inventory);
            this.currentLevel = level;

        }
    }
}

