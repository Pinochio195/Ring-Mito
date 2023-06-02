using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
    }

    private void OnMouseDown()
    {
        BalloonManager.Instance.isCheckClickDestroyBalloon = true;
        GameManager.Instance._star._listButton.ForEach(item =>
        {
            item.GetComponent<Image>().raycastTarget = true;
        });
    }
}
