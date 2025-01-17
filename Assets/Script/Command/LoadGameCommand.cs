using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DuyBui.MenuManager;

namespace DuyBui
{
    public class LoadGameCommand : IMenuCommand
    {
        public void Execute()
        {
            //TODO: LOAD GAME
            Debug.Log("Loading saved game...");
            SceneManager.LoadScene(GameManager.Instance.LoadLevel());
        }
    }
}
