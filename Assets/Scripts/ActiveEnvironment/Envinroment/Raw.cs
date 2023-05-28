using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raw : MonoBehaviour
{
    public float rotationSpeed = 10f;   // Vận tốc xoay
    public RotationDirection direction; // Enum để chọn hướng xoay
    
    public enum RotationDirection
    {
        Clockwise,
        CounterClockwise
    }

    private void Update()
    {
        if (Pedestal.Instance.isRotating)
        {
            if (Pedestal.Instance.isCounterClockwise)
            {
                direction = RotationDirection.CounterClockwise;
            }
            else
            {
                direction = RotationDirection.Clockwise;
            }
            Rotate();
        }
    }

    private void Rotate()
    {
        // Tính toán góc xoay dựa trên hướng chọn
        float rotationAngle = rotationSpeed * Time.deltaTime;

        if (direction == RotationDirection.CounterClockwise)
        {
            rotationAngle = -rotationAngle;
        }

        // Xoay đối tượng quanh trục forward
        transform.Rotate(Vector3.forward, rotationAngle);
    }
}