using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxCheck : MonoBehaviour
{
    public Mushroom namMushroom;

    private void OnMouseDown()
    {
        namMushroom.EnableFan();
    }

    private void OnMouseUp()
    {
        namMushroom.DisableFan();
    }

    
}