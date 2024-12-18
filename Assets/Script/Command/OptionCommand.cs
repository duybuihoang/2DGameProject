using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DuyBui.MenuManager;

namespace DuyBui
{
    public class OptionCommand : IMenuCommand
    {
        public void Execute()
        {
            //TODO: popup option menu
            MenuManager.Instance.SetMenuState(MenuState.Options);

        }
    }
}
