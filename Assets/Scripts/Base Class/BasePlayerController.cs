using System;
using System.Collections;
using System.Collections.Generic;
using Ring;
using UnityEngine;

public abstract class BasePlayerController : MonoBehaviour
{
    //Player Component
    [HeaderTextColor(0.2f, 1, 1, headerText = "Component For Player")]
    public Player_Component _playerComponent;

    [Space(10)] [HeaderTextColor(0.2f, 1, 1, headerText = "Move For Player")] [SerializeField]
    public Player_Move _playerMove;

    protected virtual void PlayerMove()
    {
        if (_playerMove.isMovingLeft)
        {
            _playerComponent._rigidbody.velocity =
                new Vector2(-_playerMove.Speed_Move, _playerComponent._rigidbody.velocity.y);
        }
        else if (_playerMove.isMovingRight)
        {
            _playerComponent._rigidbody.velocity =
                new Vector2(_playerMove.Speed_Move, _playerComponent._rigidbody.velocity.y);
        }
    }

    public virtual void StartMovingLeft()
    {
        _playerMove.isMovingLeft = true;
        _playerComponent._skeletonAnimation.skeleton.ScaleX = -1f; // Quay Player về phía trái
        _playerComponent._skeletonAnimation.AnimationName = "walk";
    }

    public virtual void StopMovingLeft()
    {
        _playerMove.isMovingLeft = false;
        _playerComponent._skeletonAnimation.AnimationName = "idle";
        if (_playerComponent._rigidbody.velocity != Vector3.zero)
        {
            _playerComponent._rigidbody.velocity = Vector3.zero;
        }
    }

    public virtual void StartMovingRight()
    {
        _playerMove.isMovingRight = true;
        _playerComponent._skeletonAnimation.skeleton.ScaleX = 1f; // Quay Player về phía phải
        _playerComponent._skeletonAnimation.AnimationName = "walk";
    }

    public virtual void StopMovingRight()
    {
        _playerMove.isMovingRight = false;
        _playerComponent._skeletonAnimation.AnimationName = "idle";

        if (_playerComponent._rigidbody.velocity != Vector3.zero)
        {
            _playerComponent._rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnMouseDown()
    {
        OnClickObject();
    }
    protected abstract void OnClickObject();
}