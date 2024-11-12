using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    [CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/State Data/Move State")]

    public class D_MoveState : ScriptableObject
    {
        public float movementSpeed = 3f;

        public float minRoamingTime = 2.0f;
        public float maxRoamingTime = 4.0f;

    }
}
