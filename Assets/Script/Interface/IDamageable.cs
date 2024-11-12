using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    void Damage(float amount);
    void EmitHitParticle(Vector3 selfPos, Vector3 targetPos);
}
