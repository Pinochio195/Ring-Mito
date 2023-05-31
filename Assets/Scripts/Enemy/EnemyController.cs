using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : BaseEnemy
{
    [SerializeField] private Collider _collider;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Move()
    {
        base.Move();
    }

    protected override void OnClickObject()
    {
        ChangeAnimation();
    }

    protected override void ChangeAnimation()
    {
        base.ChangeAnimation();

        if (_enemyComponent._skeletonAnimation.AnimationName == "idle")
        {
            _collider.enabled = false;
            _collider.isTrigger = true;
            PlayAnimation("tron", null, false);
        }
        else
        {
            _collider.enabled = false;
            _collider.isTrigger = false;
            PlayAnimation("xuat_hien", () => { _enemyComponent._skeletonAnimation.AnimationName = "idle"; }, false);
        }
    }


    private void PlayAnimation(string animationName, Action onAnimationComplete = null, bool loop = true)
    {
        _enemyComponent._skeletonAnimation.AnimationName = animationName;
        var trackEntry = _enemyComponent._skeletonAnimation.state.GetCurrent(0);
        trackEntry.Loop = loop;
        trackEntry.Complete += (entry) =>
        {
            onAnimationComplete?.Invoke();
            _collider.enabled = true;
        };
    }
    
}