using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class ExitCommand : IMenuCommand
    {
        public void Execute()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
