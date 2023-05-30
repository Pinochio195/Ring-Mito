using System;
using System.Collections;
using System.Collections.Generic;
using Ring;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : BasePlayerController
{
    #region Singleton

    // Singleton instance
    private static PlayerController instance;

    // Singleton accessor
    public static PlayerController Instance
    {
        get { return instance; }
    }

    #endregion

    #region Component

    [Space(10)] [HeaderTextColor(0.2f, 1, 1, headerText = "Move For Player")]
    public TimeToSleep _sleepTime;

    [Space(10)] [HeaderTextColor(0.2f, 1, 1, headerText = "Jump For Player")]
    public Player_Jump _playerJump;

    #endregion

    private void Awake()
    {
        // Ensure only one instance of the player exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
    }

    private void Update()
    {
        CheckPlayerJump();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    #region Move Player

    protected override void PlayerMove()
    {
        base.PlayerMove();
        if (_playerMove.isMovingLeft)
        {
            _sleepTime.isCheckTime = true;
        }
        else if (_playerMove.isMovingRight)
        {
            _sleepTime.isCheckTime = true;
        }
        else
        {
            if (_sleepTime.isCheckTime)
            {
                _sleepTime._timeTouch += Time.deltaTime;
                if (_sleepTime._timeTouch > 5f)
                {
                    _playerComponent._skeletonAnimation.AnimationName = "sleep";
                    _sleepTime.isCheckTime = false;
                }
            }
            else
            {
                _sleepTime._timeTouch = 0;
            }
        }
    }

    public override void StartMovingLeft()
    {
        #region Sleep

        _sleepTime._timeTouch = 0;

        #endregion

        base.StartMovingLeft();
    }

    public override void StopMovingLeft()
    {
        base.StopMovingLeft();
    }

    public override void StartMovingRight()
    {
        #region Sleep

        _sleepTime._timeTouch = 0;

        #endregion

        base.StartMovingRight();
    }

    public override void StopMovingRight()
    {
        base.StopMovingRight();
    }

    protected override void OnClickObject()
    {
        if (_playerComponent._girlController.enabled)
        {
            _playerComponent._girlController.enabled = false;
        }
        _playerComponent._boyController.enabled = true;
        
        
    }

    #endregion

    #region Check Player trên không để jump

    void CheckPlayerJump()
    {
        _playerJump.isCheckGround = Physics.Raycast(_playerJump.groundCheckTransform.position, Vector3.down,
            _playerJump.rayDistance, LayerMask.GetMask("Ground", "GroundLow"));
        Debug.DrawRay(_playerJump.groundCheckTransform.position, Vector3.down * _playerJump.rayDistance, Color.red);
        if (_playerJump.isCheckGround && !_playerMove.isMovingLeft && !_playerMove.isMovingRight &&
            (_playerComponent._skeletonAnimation.AnimationName == "walk" ||
             _playerComponent._skeletonAnimation.AnimationName == "jump1"))
        {
            _playerComponent._skeletonAnimation.AnimationName = "idle";
        }
        else if ((_playerJump.isCheckGround && (_playerMove.isMovingLeft || _playerMove.isMovingRight)) &&
                 _playerComponent._skeletonAnimation.AnimationName != "walk")
        {
            _playerComponent._skeletonAnimation.AnimationName = "walk";
        }
        else if (!_playerJump.isCheckGround)
        {
            _playerComponent._skeletonAnimation.AnimationName = "jump1";
        }
    }

    #endregion
}