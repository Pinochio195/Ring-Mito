using UnityEngine;

public class SteeringWheelRotation : MonoBehaviour
{
    // Singleton instance
    private static SteeringWheelRotation instance;

    // Singleton accessor
    public static SteeringWheelRotation Instance
    {
        get { return instance; }
    }
    public GameObject objectToMove;
    public float moveSpeed = 1f;

    private bool isDragging = false;
    private Vector2 previousPosition;
    public bool isRotating;//cho raw xoay theo vòng quay
    public bool isCounterClockwise;//cho raw xoay theo vòng quay
    private void Awake()
    {
        // Ensure only one instance of the player exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    private void OnMouseDown()
    {
        isDragging = true;
        previousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        isDragging = false;
        isRotating = false;
    }

    private void OnMouseDrag()
    {
        Debug.Log(123);
        if (isDragging)
        {
            Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float angle = Vector2.SignedAngle(previousPosition - (Vector2)transform.position, currentPosition - (Vector2)transform.position);
            transform.Rotate(Vector3.forward, angle);
            previousPosition = currentPosition;

            // Di chuyển object A
            float moveAmount = angle *Time.deltaTime * moveSpeed*0.001f;
            Vector3 moveDirection = moveAmount > 0 ? Vector3.up : Vector3.down;
            //isCounterClockwise
            isCounterClockwise = (moveDirection == Vector3.up);
            isRotating = true;
            objectToMove.transform.Translate(moveDirection * Mathf.Abs(moveAmount));
        }
    }
}