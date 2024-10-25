using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class Dummy : MonoBehaviour, IDamageable
    {
        public void Damage(float amount)
        {
            Debug.Log(this.name + "taken damage");
        }
    }
}
