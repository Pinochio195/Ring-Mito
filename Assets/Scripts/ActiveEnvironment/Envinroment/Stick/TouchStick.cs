using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchStick : BaseCollider
{
    //[SerializeField] private Rigidbody2D _rigidbody2D;
    private bool isCheck;
    private Vector2 _direction;
    public float _speed;
    private void Update()
    {
        if (isCheck)
        {
            Wood.GetComponent<Rigidbody2D>().velocity = _direction*_speed;
        }
    }

    private void OnMouseDown()
    {
        isCheck = true;
        //_rigidbody2D.isKinematic = false;
        if (moveDirection == MoveDirection.Right)
        {
            _direction = Vector2.up;
        }
        else
        {
            _direction = Vector2.down;
        }
        #region Tutorials

        if (GameManager.Instance._tutorials._enumTutorials == Ring.Tutorials.EnumTutorials.Step1)
        {
            GameManager.Instance._tutorials._enumTutorials = Ring.Tutorials.EnumTutorials.StepEnd;
            GameManager.Instance._tutorials.ischeckState = true;
        }

        #endregion
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
