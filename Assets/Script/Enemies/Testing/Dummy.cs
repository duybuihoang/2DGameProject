using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class Dummy : MonoBehaviour, IDamageable
    {
        private Rigidbody2D RB;
        private void Start()
        {
            RB = GetComponent<Rigidbody2D>();
        }
        public void Damage(float amount)
        {
            RB.AddForce(new Vector2(10, 10));
        }
    }
}
