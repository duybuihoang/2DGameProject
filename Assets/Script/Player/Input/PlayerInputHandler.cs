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

    public void OnSpaceButtonInput(InputAction.CallbackContext context)
    {
        if (context.started)
            RollInput = true;
    }
    public void UseRollInput() => RollInput = false;



}
