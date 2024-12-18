using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class MenuCommandFactory : MonoBehaviour
    {
        public static IMenuCommand CreateCommand(string commandType)
        {
            switch (commandType.ToLower())
            {
                case "newgame":
                    return new NewGameCommand();
                case "loadgame":
                    return new LoadGameCommand();
                case "options":
                    return new OptionCommand();
                case "exit":
                    return new ExitCommand();
                default:
                    throw new ArgumentException("Unknown command type");
            }
        }
    }
}
