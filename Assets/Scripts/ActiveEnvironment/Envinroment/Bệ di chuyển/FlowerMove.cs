using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMove : BaseObjectMovement
{
    public int _breakPoint;
    public override void Update()
    {
        if (isCheckMove)
        {
            // Kiểm tra nếu object đã đến được transform cuối cùng
            if (currentTargetIndex == _breakPoint &&_breakPoint!=0 )
            {
                Debug.Log("ngưng tại đây");
                return;
            }
        }
        base.Update();
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        if (currentTargetIndex == _breakPoint)
        {
            _breakPoint = 0;
        }
    }

    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
    }
}
