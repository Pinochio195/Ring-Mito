using System;
using System.Collections;
using System.Collections.Generic;
using Ring;
using Spine;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : BasePlayerController, ICollWithPlayer
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

    #endregion

    protected override void OnClickObject()
    {
        
    }

    #region Check Player trên không để jump

    void CheckPlayerJump()
    {
        _playerJump.isCheckGround = Physics.Raycast(_playerJump.groundCheckTransform.position, Vector3.down,
            _playerJump.rayDistance, LayerMask.GetMask("Ground", "GroundLow","Environment","Box"));
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


    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Lava") || other.gameObject.CompareTag("Enemy"))
        {
            #region Ngừng không cho di chuyển khi thua

            _playerMove.isMovingLeft = false;
            _playerMove.isMovingRight = false;
            

            #endregion
            GameManager.Instance._star._listButton.ForEach(item=>item.SetActive(false));
            PlayAnimation("hurt", () => { PlayAnimation("die", null, false); }, false);
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    #region Thực hiện xong animation hurt => die và dừng ở frame cuối

    private void PlayAnimation(string animationName, Action onAnimationComplete = null, bool loop = true)
    {
        _playerComponent._skeletonAnimation.AnimationName = animationName;
        var trackEntry = _playerComponent._skeletonAnimation.state.GetCurrent(0);
        trackEntry.Loop = loop;
        trackEntry.Complete += (entry) =>
        {
            onAnimationComplete?.Invoke();
            _sleepTime.isCheckTime = false; //không cho chuyển về animation sleep nữa
        };
    }

    #endregion
}