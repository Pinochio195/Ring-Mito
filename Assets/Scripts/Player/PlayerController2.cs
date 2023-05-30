using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : BasePlayerController
{
    #region Singleton

    private static PlayerController2 instance;

    public static PlayerController2 Instance
    {
        get { return instance; }
    }

    #endregion

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    protected override void PlayerMove()
    {
        base.PlayerMove();
    }

    public override void StartMovingLeft()
    {
        base.StartMovingLeft();
    }

    public override void StopMovingLeft()
    {
        base.StopMovingLeft();
    }

    public override void StartMovingRight()
    {
        base.StartMovingRight();
    }

    public override void StopMovingRight()
    {
        base.StopMovingRight();
    }

    protected override void OnClickObject()
    {
        if (_playerComponent._boyController.enabled)
        {
            _playerComponent._boyController.enabled = false;
        }
        _playerComponent._girlController.enabled = true;
        _playerComponent._boyController.gameObject.transform.Find("Arrow").gameObject.SetActive(false);
        _playerComponent._girlController.gameObject.transform.Find("Arrow").gameObject.SetActive(true);
    }
}