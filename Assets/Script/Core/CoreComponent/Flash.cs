using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.CoreSystem
{
    public class Flash : CoreComponent
    {
        [SerializeField] private float flashTime = 0.2f;
        [SerializeField] private Material flashMat;

        private Material originalMat;
        private SpriteRenderer spriteRenderer;

        private Coroutine flashRoutine;

        protected override void Awake()
        {
            base.Awake();

            spriteRenderer = GetComponentInParent<SpriteRenderer>();
            originalMat = spriteRenderer.material;

        }
        private IEnumerator FlashRoutine()
        {
            spriteRenderer.material = flashMat;
            yield return new WaitForSeconds(flashTime);

            spriteRenderer.material = originalMat;
            flashRoutine = null;
        }

        public void StartFlash()
        {
            if(flashRoutine != null)
            {
                StopCoroutine(flashRoutine);
            }
            flashRoutine = StartCoroutine(FlashRoutine());
        }    

    }
}
