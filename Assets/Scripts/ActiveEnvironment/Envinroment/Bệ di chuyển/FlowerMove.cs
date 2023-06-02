using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMove : BaseObjectMovement
{
    public int _breakPoint;
    public int _breakPointLeft;

    private void Start()
    {
        _breakPointLeft = _breakPoint;
    }

    public override void Update()
    {
        if (isCheckMove)
        {
            // Kiểm tra nếu object đã đến được transform cuối cùng
            if (currentTargetIndex == _breakPointLeft && _breakPointLeft != 0)
            {
                Debug.Log("ngưng tại đây");
                return;
            }
        }

        base.Update();
        if (isCheckMove)
        {
            if (currentTargetIndex >= _listTargetTransforms.Count && currentTargetIndex == _listTargetTransforms.Count)
            {
                Debug.Log(123);
                this._breakPointLeft = this._breakPoint;
                return;
            }
        }
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        if (currentTargetIndex == _breakPointLeft)
        {
            _breakPointLeft = 0;
        }
    }

    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
    }
}