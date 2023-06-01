using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
    }

    private void OnMouseDown()
    {
        Debug.Log(123);
        BalloonManager.Instance.isCheckClickDestroyBalloon = true;
    }
}
