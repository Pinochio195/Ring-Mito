using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlowerMove : BaseObjectMovement
{
    public int _breakPoint;
    public int _breakPointLeft;

    public override void Start()
    {
        base.Start();
        _breakPointLeft = _breakPoint;
    }

    public override void Update()
    {
        if (isCheckMove)
        {
            // Kiểm tra nếu object đã đến được transform cuối cùng
            if (currentTargetIndex == _breakPointLeft && _breakPointLeft != 0)
            {
                return;
            }
        }
        base.Update();
        if (this._breakPointLeft != this._breakPoint && transform.position.Equals(_listTargetOriginal[0].position))
        {
            Debug.Log(123);
            this._breakPointLeft = this._breakPoint;
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