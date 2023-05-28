using System;
using System.Collections;
using System.Collections.Generic;
using Ring;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Singleton instance
    private static PlayerController instance;

    // Singleton accessor
    public static PlayerController Instance
    {
        get { return instance; }
    }

    //Player Component
    [HeaderTextColor(0.2f, 1, 1, headerText = "Component For Player")]
    public Player_Component _playerComponent;

    [Space(10)] [HeaderTextColor(0.2f, 1, 1, headerText = "Move For Player")] [SerializeField]
    public Player_Move _playerMove;

    [Space(10)] [HeaderTextColor(0.2f, 1, 1, headerText = "Move For Player")] [SerializeField]
    TimeToSleep _sleepTime;

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
}