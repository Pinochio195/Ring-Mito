using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchStick : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private void OnMouseDown()
    {
        _rigidbody2D.isKinematic = false;
        #region Tutorials

        if (GameManager.Instance._tutorials._enumTutorials == Ring.Tutorials.EnumTutorials.Step1)
        {
            GameManager.Instance._tutorials._enumTutorials = Ring.Tutorials.EnumTutorials.StepEnd;
            GameManager.Instance._tutorials.ischeckState = true;
        }

        #endregion
    }
}
