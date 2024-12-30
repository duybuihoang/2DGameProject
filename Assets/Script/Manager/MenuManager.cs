using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class MenuManager : MonoBehaviour
    {
        private static MenuManager instance;
        public static MenuManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = FindObjectOfType<MenuManager>();
                    if(instance == null)
                    {
                        GameObject go = new GameObject("MenuManager");
                        instance = go.AddComponent<MenuManager>();
                    }
                }
                return instance;
            }
        }

        public enum MenuState
        {
            MainMenu,
            Loading,
            Options,
            InGame
        }

        private MenuState currentState;
        public event Action<MenuState> OnMenuStateChanged;


        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }


        public void SetMenuState(MenuState newState)
        {
            currentState = newState;
            OnMenuStateChanged?.Invoke(currentState);
        }


    }
}