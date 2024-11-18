using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Projectile : MonoBehaviour
{
    protected Vector3 startPos;
    protected bool isMaxRange;
    public float damage;

    protected virtual void Start()
    {
        Vector3 startPos = this.transform.position;
        isMaxRange = false;
    }
    public virtual void Fire(Vector3 start, Vector3 dest, float damage)
    {
        this.damage = damage;
    }
    public virtual bool CheckMaxRange()
    {
        return false;
    }

}

