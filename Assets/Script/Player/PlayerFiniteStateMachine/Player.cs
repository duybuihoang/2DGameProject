using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }
    public Core Core { get; private set; }
    private Rigidbody2D rb;
    public PlayerInputHandler InputHandler { get; private set; }
    public Animator Anim { get; private set; }

    [SerializeField]
    private PlayerData playerData;


    #region States

    public IdleState idleState { get; private set; }
    public MoveState moveState { get; private set; }
    public AttackState attackState { get; private set; }


    #endregion



    private void Awake()
    {
        Core = GetComponentInChildren<Core>();

        StateMachine = gameObject.AddComponent<PlayerStateMachine>();

        idleState = new IdleState(this, StateMachine, playerData, "Idle");
        moveState = new MoveState(this, StateMachine, playerData, "Walk");
        attackState = new AttackState(this, StateMachine, playerData, "Attack");

    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Anim = GetComponent<Animator>();

        StateMachine.Initialize(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        Core.LogicUpdate();
        StateMachine.currentState.LogicUpdate();
        
    }

    private void FixedUpdate()
    {
        StateMachine.currentState.PhysicsUpdate();
    }
}
