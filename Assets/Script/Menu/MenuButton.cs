using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class MenuButton : MonoBehaviour
    {
        [SerializeField] private string commandType;
        private IMenuCommand command;


        private void Start()
        {
            command = MenuCommandFactory.CreateCommand(commandType);
        }

        public void OnClick()
        {
            command.Execute();
        }
    }
}
