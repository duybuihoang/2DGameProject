using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    [CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/State Data/Idle State")]
    public class D_IdleState : ScriptableObject
    {
        public float minIdleTime = 1.0f;
        public float maxIdleTime = 2.0f;
    }
}
