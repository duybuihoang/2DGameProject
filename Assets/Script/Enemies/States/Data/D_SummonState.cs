using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    [CreateAssetMenu(fileName = "newSummonStateData", menuName = "Data/State Data/Summon State")]
    public class D_SummonState : ScriptableObject
    {
        public int maxSummonCount = 6;
        public int minSmmonCount = 4;
        public List<GameObject> summonList;
        public float summonRadius = 1f;
    }
}
