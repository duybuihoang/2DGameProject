using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    [CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
    public class D_Entity : ScriptableObject
    {
        public float maxHealth = 30f;

        public LayerMask whatIsGround;
        public LayerMask whatIsPlayer;
    }

}
