using System;
using System.Collections;
using System.Collections.Generic;
using Ring;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

    //Player Component
    [HeaderTextColor(0.2f, 1, 1, headerText = "Component For Player")]
    public Player_Component _playerComponent;

    [Space(10)] [HeaderTextColor(0.2f, 1, 1, headerText = "Move For Player")] [SerializeField]
    public Player_Move _playerMove;

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

    void PlayerMove()
    {
        if (_playerMove.isMovingLeft)
        {
            _sleepTime.isCheckTime = true;
            _playerComponent._rigidbody.velocity =
                new Vector2(-_playerMove.Speed_Move, _playerComponent._rigidbody.velocity.y);
        }
        else if (_playerMove.isMovingRight)
        {
            _sleepTime.isCheckTime = true;
            _playerComponent._rigidbody.velocity =
                new Vector2(_playerMove.Speed_Move, _playerComponent._rigidbody.velocity.y);
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

    public void StartMovingLeft()
    {
        #region Sleep

        _sleepTime._timeTouch = 0;

        #endregion

        _playerMove.isMovingLeft = true;

        _playerComponent._skeletonAnimation.skeleton.ScaleX = -1f; // Quay Player về phía trái
        _playerComponent._skeletonAnimation.AnimationName = "walk";
    }

    public void StopMovingLeft()
    {
        _playerMove.isMovingLeft = false;
        _playerComponent._skeletonAnimation.AnimationName = "idle";

        if (_playerComponent._rigidbody.velocity != Vector2.zero)
        {
            _playerComponent._rigidbody.velocity = Vector2.zero;
        }
    }

    public void StartMovingRight()
    {
        #region Sleep

        _sleepTime._timeTouch = 0;

        #endregion

        _playerMove.isMovingRight = true;
        _playerComponent._skeletonAnimation.skeleton.ScaleX = 1f; // Quay Player về phía phải
        _playerComponent._skeletonAnimation.AnimationName = "walk";
    }

    public void StopMovingRight()
    {
        _playerMove.isMovingRight = false;
        _playerComponent._skeletonAnimation.AnimationName = "idle";

        if (_playerComponent._rigidbody.velocity != Vector2.zero)
        {
            _playerComponent._rigidbody.velocity = Vector2.zero;
        }
    }

    #endregion

    #region Check Player trên không để jump

    void CheckPlayerJump()
    {
        _playerJump.isCheckGround = Physics2D.Raycast(_playerJump.groundCheckTransform.position, Vector2.down,
            _playerJump.rayDistance, LayerMask.GetMask("Ground", "GroundLow"));
        Debug.DrawRay(_playerJump.groundCheckTransform.position, Vector2.down * _playerJump.rayDistance, Color.red);
        if (_playerJump.isCheckGround && !_playerMove.isMovingLeft && !_playerMove.isMovingRight && (_playerComponent._skeletonAnimation.AnimationName == "walk"||_playerComponent._skeletonAnimation.AnimationName == "jump1"))
        {
            _playerComponent._skeletonAnimation.AnimationName = "idle";
            Debug.Log(123);
        }
        else if ((_playerJump.isCheckGround &&( _playerMove.isMovingLeft || _playerMove.isMovingRight)) && _playerComponent._skeletonAnimation.AnimationName != "walk" )
        {
            Debug.Log(2);
            _playerComponent._skeletonAnimation.AnimationName = "walk";
        }
        else if(!_playerJump.isCheckGround)
        {
            Debug.Log(3);
            _playerComponent._skeletonAnimation.AnimationName = "jump1";
        }
    }

    #endregion
    
    
}