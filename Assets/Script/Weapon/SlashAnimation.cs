using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class SlashAnimation : MonoBehaviour
    {
        public void OnFinished()
        {
            Destroy(gameObject);
        }
    }
}
