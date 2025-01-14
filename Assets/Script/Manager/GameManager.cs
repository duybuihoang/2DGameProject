using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DuyBui
{
    public class GameManager : MonoBehaviour
    {
        private GameObject player;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        // Start is called before the first frame update
        void Start()
        {
            if(AudioManager.Instance)
            {
                AudioManager.Instance.PlayBGM("game-music-loop-7-145285");
            }

            MenuManager.Instance.SetMenuState(MenuManager.MenuState.InGame);
        
        }

        // Update is called once per frame
        void Update()
        {
            if(!player.gameObject.activeSelf)
            {
                SceneManager.LoadScene("Menu");
            }


        }
        private void OnDestroy()
        {

        }
    }
}
