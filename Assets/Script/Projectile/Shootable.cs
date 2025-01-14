using DuyBui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shootable : Projectile
{
    [SerializeField]
    private float speed; 

    [SerializeField]
    private float damageRadius;
    [SerializeField]
    private Transform damagePosition;

    private bool hasHitWall;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private LayerMask whatIsTarget;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if(!hasHitWall)
        {
            Collider2D damageHit = Physics2D.OverlapCircle(damagePosition.position,damageRadius, whatIsTarget);
            Collider2D wallHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);

            if(damageHit)
            {
                if (damageHit.TryGetComponent(out IDamageable damageable))
                {
                    damageable.Damage(damage);
                }



                Destroy(gameObject);
            }

            if(wallHit)
            {
                hasHitWall = true;
                rb.velocity = Vector2.zero;
            }

        }    
    }

    public override void Fire(Vector3 start, Vector3 dest, float damage)
    {
        base.Fire(start, dest, damage);
        rb.velocity = (Vector2) (dest - start).normalized * speed;


        var rotate = Mathf.Atan2(dest.y - start.y, dest.x - start.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, rotate);
    }

    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
    }


}

