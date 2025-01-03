using DuyBui.CoreSystem;
using DuyBui.Weapon.Components;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }
    public Core Core { get; private set; }
    public Rigidbody2D RB;
    public PlayerInputHandler InputHandler { get; private set; }
    public Animator Anim { get; private set; }

    [SerializeField]
    private PlayerData playerData;


    #region States

    public IdleState idleState { get; private set; }
    public MoveState moveState { get; private set; }
    public RollState rollState { get; private set; }


    #endregion

    private Weapon weapon;


    private void Awake()
    {
        Core = GetComponentInChildren<Core>();

        weapon = transform.GetComponentInChildren<Weapon>();
        //weapon?.SetCore(Core);

        StateMachine = gameObject.AddComponent<PlayerStateMachine>();

        idleState = new IdleState(this, StateMachine, playerData, "Idle", weapon);
        moveState = new MoveState(this, StateMachine, playerData, "Walk", weapon);
        rollState = new RollState(this, StateMachine, playerData, "Roll");

    }


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Anim = GetComponent<Animator>();

        StateMachine.Initialize(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        Core.LogicUpdate();
        StateMachine.currentState.LogicUpdate();
        //Debug.Log(this.InputHandler.MouseInput.normalized);
        
    }

    private void FixedUpdate()
    {
        StateMachine.currentState.PhysicsUpdate();
    }


    private void AnimationTrigger() => StateMachine.currentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.currentState.AnimationFinishTrigger();

}
