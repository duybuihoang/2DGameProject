using DuyBui.Weapon.Components;
using DuyBui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class TNT : MonoBehaviour
{
    private Animator anim;
    private Projectile projectile;
    private float currentScale = 1f;
    [SerializeField] private float damageRadius = 1f;
    [SerializeField] float minimumScale = 1f;
    [SerializeField] float MaximumScale = 2f;
    [SerializeField] float knockbackStrength = 10f;
    private bool isExploded = false;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        projectile = GetComponent<Projectile>();
    }

    private void Update()
    {
        if (projectile.CheckMaxRange() && !isExploded)
        {
            anim.SetBool("explode", true);
            isExploded = true;

            randomScaleExplosion();

        }
    }

    public void Damage()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(this.transform.position, damageRadius * currentScale);

        foreach (var item in targets)
        {
            if (item.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(projectile.damage);
            }

            if (item.TryGetComponent(out IKnockbackable knockbackable))
            {
                knockbackable.KnockBack((item.transform.position - this.transform.position).normalized, knockbackStrength);
            }

        }

    }

    private void randomScaleExplosion()
    {
        currentScale = Random.Range(minimumScale, MaximumScale);
        transform.localScale = Vector3.one * currentScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, damageRadius * currentScale);
    }

}

