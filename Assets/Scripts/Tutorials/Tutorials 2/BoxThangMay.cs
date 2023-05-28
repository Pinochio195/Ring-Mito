using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxThangMay : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log(col.gameObject.name);
        }
    }
}
