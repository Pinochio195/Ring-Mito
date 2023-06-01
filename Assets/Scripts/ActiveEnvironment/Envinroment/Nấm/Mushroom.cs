using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float fanForce = 10f;
    private bool isPressed;
    [SerializeField] private Collider clickCollider;

    private void Update()
    {
        if (Input.GetMouseButton(0)&&clickCollider.bounds.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            Debug.Log(333);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(123);
        
    }

    private void OnMouseUp()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}