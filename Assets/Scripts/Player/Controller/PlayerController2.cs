using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController2 : BasePlayerController
{
    #region Singleton

    private static PlayerController2 instance;

    public static PlayerController2 Instance
    {
        get { return instance; }
    }

    #endregion

    public GameObject _waterPrefabs;
    [HideInInspector]public GameObject _waterGameObject;
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
        
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            _waterGameObject = Instantiate(_waterPrefabs, other.gameObject.transform);
            _waterGameObject.transform.position = new Vector3(other.transform.position.x, other.transform.position.y+.5f, other.transform.position.z);
            Destroy(gameObject);
        }
    }
}