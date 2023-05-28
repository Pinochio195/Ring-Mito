using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpring : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        /*Debug.Log("Exit");
        //PlayerController.Instance.isCheckJumpSpring = false;
        if (other.gameObject.CompareTag("Player"))
        {
        }*/
            //PlayerController.Instance._playerComponent._rigidbody.AddForce(Vector2.up * 30f, ForceMode2D.Impulse);
    }
}