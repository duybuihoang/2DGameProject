using DuyBui.Weapon.Components;
using DuyBui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    private Animator anim;
    private Projectile projectile;
    [SerializeField] private float damageRadius = 1f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        projectile = GetComponent<Projectile>();
    }

    private void Update()
    {
        if (projectile.CheckMaxRange())
            anim.SetBool("explode", true);
    }

    public void Damage()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(this.transform.position, damageRadius);

        foreach (var item in targets)
        {
            if (item.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(projectile.damage);
            }

            if (item.TryGetComponent(out IKnockbackable knockbackable))
            {
                knockbackable.KnockBack((item.transform.position - this.transform.position).normalized, 10f);
            }

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }

}

