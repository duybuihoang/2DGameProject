using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class DarkPanelButton : MonoBehaviour
    {
        public void onclick()
        {
            MenuManager.Instance.SetMenuState(MenuManager.MenuState.MainMenu);
        }
    }
}
