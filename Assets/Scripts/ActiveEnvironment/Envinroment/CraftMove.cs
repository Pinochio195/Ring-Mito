using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class CraftMove : BaseObjectMovement
{
    [SerializeField] private SkeletonAnimation _skeletonAnimation;
    public override void Update()
    {
        base.Update();
        if (isCheckMove)
        {
            // Kiểm tra nếu object đã đến được transform cuối cùng
            if (currentTargetIndex >= _listTargetTransforms.Count)
            {
                _skeletonAnimation.AnimationName = "idle";
                return;
            }
        }
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        _skeletonAnimation.AnimationName = "Skill_L";
    }

    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
    }
}
