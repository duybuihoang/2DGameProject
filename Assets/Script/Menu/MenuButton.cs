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
            AudioManager.Instance.PlaySFX("90s-game-ui-6-185099");
            command.Execute();
        }
    }
}
