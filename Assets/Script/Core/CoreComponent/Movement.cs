using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : CoreComponent
{
    private Rigidbody2D RB;

    public int FacingDirection { get; private set; }
    public Vector2 currentVelocity { get; private set; }
    private Vector2 workspace;

    public bool canSetVelocity { get; private set; }


    protected override void Awake()
    {
        base.Awake();

        FacingDirection = 1;
        canSetVelocity = true;
        RB = GetComponentInParent<Rigidbody2D>();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        currentVelocity = RB.velocity;

    }

    #region Set Function

    public void SetVelocity(Vector2 direction, float velocity)
    {
        workspace = direction * velocity;
        SetFinalVelocity();
    }

    public void SetVelocityZero()
    {
        workspace = Vector2.zero;
        SetFinalVelocity();
    }    

    public void SetFinalVelocity()
    {
        if(canSetVelocity)
        {
            RB.velocity = workspace;
            currentVelocity = workspace;
        }    
    }
    public void CheckIfShouldFlip(Vector2 mousePos, float xInput)
    {
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(RB.transform.position);

        /*if (xInput != 0 && xInput * FacingDirection < 0)
        {
            Flip();
        }*/

        if (FacingDirection == 1)
        {
            if (mousePos.x < playerScreenPoint.x)
            {
                Flip();
            }
        }
        else
        {
            if(mousePos.x >= playerScreenPoint.x)
            {
                Flip();
            }    
        }    

    }
    public void Flip()
    {
        FacingDirection *= -1;
        RB.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    #endregion



}
