using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


public class Throwable : Projectile
{
    [SerializeField] private float duration = 1f;
    [SerializeField] private float heightY = 1f;
    [SerializeField] private GameObject shadow;
    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private Vector3 shadowOffset;


    private Vector3 throwableShadowPosition;
    private GameObject throwableShadow;


    protected override void Start()
    {
        base.Start();

      

    }
    private IEnumerator CurveProjectile(Vector3 startPos, Vector3 endPos)
    {
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / duration;
            float heightT = animCurve.Evaluate(linearT);
            float height = Mathf.Lerp(0f, heightY, heightT);

            transform.position = Vector2.Lerp(startPos, endPos, linearT) + new Vector2(0f, height);
            yield return null;
        }
        isMaxRange = true;
    }

    private IEnumerator MoveShadow(GameObject shadow,Vector3 startPos, Vector3 endPos)
    {
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / duration;
            shadow.transform.position = Vector2.Lerp(startPos, endPos, linearT);
            yield return null;

        }
        Destroy(shadow);
    }

    public override void Fire(Vector3 start, Vector3 dest, float damage)
    {
        base.Fire(start, dest, damage);
        StartCoroutine(CurveProjectile(start, dest));

        GameObject throwableShadow = Instantiate(shadow, transform.position + shadowOffset, Quaternion.identity);
        throwableShadowPosition = throwableShadow.transform.position;

        StartCoroutine(MoveShadow(throwableShadow, throwableShadowPosition, dest));
    }
    public override bool CheckMaxRange() => isMaxRange;
}

