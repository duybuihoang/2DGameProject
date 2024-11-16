using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Projectile
{
    public class TNT : MonoBehaviour
    {
        [SerializeField] private float duration = 1f;
        [SerializeField] private float heightY = 1f;
        [SerializeField] private GameObject shadow;
        [SerializeField] private AnimationCurve animCurve;

        private void Start()
        {
            GameObject dynamiteShadow = Instantiate(shadow, transform.position + new Vector3(0f, -0.3f, 0f), Quaternion.identity);

            Vector3 startPos = this.transform.position;
            Vector3 shadowStartPos = dynamiteShadow.transform.position;
            StartCoroutine(CurveRoutine(transform.position, new Vector3(10, 10, 10)));

        }

        private IEnumerator CurveRoutine(Vector3 startPos, Vector3 endPos)
        {
            float timePassed = 0f;

            while(timePassed <= duration)
            {
                timePassed += Time.deltaTime;
                float linearT = timePassed / duration;
                float heightT = animCurve.Evaluate(linearT);
                float height = Mathf.Lerp(0f, heightY, heightT);

                transform.position = Vector2.Lerp(startPos, endPos, linearT) + new Vector2(0f, height);
                yield return null;
            }
            Destroy(gameObject);
        }
    }
}
