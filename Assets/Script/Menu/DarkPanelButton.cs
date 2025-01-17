using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class DarkPanelButton : MonoBehaviour
    {
        public void onclick()
        {
            if (MenuManager.Instance.CurrentState == MenuManager.MenuState.Options)
            {
                MenuManager.Instance.SetMenuState(MenuManager.MenuState.MainMenu);
            }
            else
            {
                MenuManager.Instance.SetMenuState(MenuManager.MenuState.InGame);
            }
        }
    }
}
