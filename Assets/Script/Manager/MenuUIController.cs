using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DuyBui.MenuManager;

namespace DuyBui
{
    public class MenuUIController : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject optionsPanel;
        //[SerializeField] private GameObject loadingPanel;


        private void Start()
        {
            MenuManager.Instance.OnMenuStateChanged += HandleMenuStateChanged;
            AudioManager.Instance.PlayBGM("game-music-loop-6-144641");
            MenuManager.Instance.SetMenuState(MenuState.MainMenu);
        }

        private void OnDestroy()
        {
            MenuManager.Instance.OnMenuStateChanged -= HandleMenuStateChanged;
            //AudioManager.Instance.StopBGM();
        }

        private void HandleMenuStateChanged(MenuState newState)
        {
            mainMenuPanel?.SetActive(newState == MenuState.MainMenu);
            optionsPanel?.SetActive(newState == MenuState.Options);
            //loadingPanel?.SetActive(newState == MenuState.Loading);
        }
    }
}
