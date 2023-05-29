using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển
    public float upDistance = 1f; // Khoảng cách di chuyển lên
    public float downDistance = 1f; // Khoảng cách di chuyển xuống

    private Vector3 initialPosition;
    private float elapsedTime = 0f;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        // Di chuyển theo hướng lên và xuống
        float yPosition = initialPosition.y + Mathf.Sin(elapsedTime * moveSpeed) * upDistance - downDistance;
        transform.localPosition = new Vector3(transform.localPosition.x, yPosition, transform.localPosition.z);
    }
}