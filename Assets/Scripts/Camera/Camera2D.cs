using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    void Start()
    {
        float Al = (float)(9f / 16f);
        float Bt = (float)Screen.width / (float)Screen.height;
        if (Bt < Al)
        {
            Camera.main.orthographicSize = (float)(Al * 5f) / (float)Bt;
        }

    }
}
