using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DuyBui
{
    public class BackToMenuButton : MonoBehaviour
    {
        [SerializeField] private Button back;

        private void Awake()
        {
            back = GetComponent<Button>();
        }


        private void Start()
        {
            back.onClick.AddListener(Back);
        }

        private void Back()
        {
            Debug.Log(SceneManager.GetActiveScene().name == "Menu");
            if(SceneManager.GetActiveScene().name != "Menu")
            {
                GameManager.Instance.Save();

                SceneManager.LoadScene("Menu");
            }
            else
            {
                MenuManager.Instance.SetMenuState(MenuManager.MenuState.MainMenu);
            }
        }
    }
}
