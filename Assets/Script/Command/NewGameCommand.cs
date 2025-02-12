using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DuyBui.MenuManager;

namespace DuyBui
{
    public class NewGameCommand : IMenuCommand
    {
        public void Execute()
        {
            MenuManager.Instance.SetMenuState(MenuState.InGame);
            Debug.Log(MenuManager.Instance.CurrentState);
            SceneManager.LoadScene("Level1");
        }
    }
}
