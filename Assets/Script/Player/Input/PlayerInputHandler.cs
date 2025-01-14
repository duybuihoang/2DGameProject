using DuyBui;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;

    public Vector2 RawMovementInput { get; private set; }
    public Vector2 MouseInput { get; private set; }
   

    public float inputX { get; private set; }

    public bool attack;
    public bool RollInput;
    public bool EscInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        inputX = RawMovementInput.x;
    }

    public void OnMouseInput(InputAction.CallbackContext context)
    {
        MouseInput = context.ReadValue<Vector2>();
    }    


    public void OnLeftMouseButtonInput(InputAction.CallbackContext context)
    {
        if (context.started)
            attack = true;

        if (context.canceled)
            attack = false;
    }

    public void UsedMouseInput()
    {
        attack = false;
    }

    public void OnSpaceButtonInput(InputAction.CallbackContext context)
    {
        if (context.started)
            RollInput = true;
    }

    public void OnEscButtonInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("click: " + MenuManager.Instance.CurrentState);
            if (MenuManager.Instance.CurrentState == MenuManager.MenuState.InGame)
            {
                MenuManager.Instance.SetMenuState(MenuManager.MenuState.Options);
                Time.timeScale = 0f; 

            }
            else if(MenuManager.Instance.CurrentState == MenuManager.MenuState.Options)
            {
                MenuManager.Instance.SetMenuState(MenuManager.MenuState.InGame);
                Time.timeScale = 1f; 

            }

        }
    }    

    public void UseRollInput() => RollInput = false;
    public void UseEscInput() => EscInput = false;

}
