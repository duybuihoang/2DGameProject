using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public interface IKnockbackable 
    {
        void KnockBack(Vector2 direction, float strength);
    }
}
