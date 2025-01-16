using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Projectile : MonoBehaviour
{
    protected Vector3 startPos;
    protected bool isMaxRange ;
    [SerializeField]protected float maxDuration = 5f;
    private float startTime;
    public float damage;
    private void Update()
    {
        if (Time.time >= startTime + maxDuration)
        {
            isMaxRange = true;
        }
    }

    protected virtual void FixedUpdate()
    {

    }

    protected virtual void Start()
    {
        startPos = this.transform.position;
        startTime = Time.time;
        isMaxRange = false;
    }
    public virtual void Fire(Vector3 start, Vector3 dest, float damage)
    {
        this.damage = damage;
    }
    public virtual bool CheckMaxRange()
    {
        return isMaxRange;
    }

}

