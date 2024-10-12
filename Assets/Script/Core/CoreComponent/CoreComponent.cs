using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoreComponent : MonoBehaviour
{
    protected Core core;

    public virtual void LogicUpdate()
    {

    }

    protected virtual void Awake()
    {
        core = transform.parent.GetComponent<Core>();

        if(core == null)
        {
            Debug.LogError("Core is missing!");
        }
        //core.AddComponent(this);

    }


}
