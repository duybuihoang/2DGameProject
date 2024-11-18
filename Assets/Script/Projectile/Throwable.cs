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

    private IEnumerator CurveRoutine(Vector3 startPos, Vector3 endPos)
    {
        float timePassed = 0f;

        while (timePassed <= duration)
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

    public override void Fire(Vector3 start, Vector3 dest, float damage)
    {
        base.Fire(start, dest, damage);
        StartCoroutine(CurveRoutine(start, dest));
    }
    public override bool CheckMaxRange() => isMaxRange;
}

