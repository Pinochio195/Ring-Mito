using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckForSrping : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance._playerJump.isCheckOnSpring = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance._playerJump.isCheckOnSpring = false;
        }
    }
}
