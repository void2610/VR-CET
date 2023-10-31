using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class InteractiveObjectBase : MonoBehaviour
{
    protected virtual void Start(){}
    protected virtual void Update(){}

    public virtual void OnInteractionStart(){

    }

    public virtual void OnInteractionEnd(){

    }
}
