using System;
using System.Collections;
using System.Collections.Generic;
using Ring;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    //Player Component
    [HeaderTextColor(0.2f, 1, 1, headerText = "Component For Player")]
    public Enemy_Component _enemyComponent;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _enemyComponent._skeletonAnimation.AnimationName = "idle";
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected virtual void Move()
    {
        
    }

    protected virtual void ChangeAnimation()
    {
        
    }

    private void OnMouseDown()
    {
        OnClickObject();
    }
    protected abstract void OnClickObject();
}
