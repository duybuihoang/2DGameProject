using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public interface IParticle 
    {
        public void EmitHitParticle(Vector3 selfPos, Vector3 targetPos);

    }
}
