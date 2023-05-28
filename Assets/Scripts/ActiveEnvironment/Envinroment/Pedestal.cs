using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : BaseTouch
{
    // Singleton instance
    private static Pedestal instance;

    // Singleton accessor
    public static Pedestal Instance
    {
        get { return instance; }
    }
    public float distanceX = 5f;
    public float moveSpeed = 2f; // Tốc độ di chuyển
    private Coroutine moveCoroutine; // Coroutine để di chuyển từ từ
    private bool isMoved ; // Trạng thái đã di chuyển

    public float rotationSpeed = 60f; // Vận tốc xoay
    public bool isRotating;      // Biến để bật/tắt xoay
    public bool isCounterClockwise;
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
    private IEnumerator RotateWoodSmoothly(float rotateAngle, float rotateSpeed)
    {
        float angleRemaining = rotateAngle;
        float elapsedTime = 0f;
        while (Mathf.Abs(angleRemaining) > 0.01f)
        {
            // Tính toán góc xoay mới dựa trên tốc độ và thời gian
            float rotateStep = rotateSpeed * Time.deltaTime;
            float rotationAmount = Mathf.Clamp(rotateStep, 0f, Mathf.Abs(angleRemaining)) * Mathf.Sign(angleRemaining);
            Quaternion newRotation = Quaternion.Euler(0f, 0f, rotationAmount) * transform.rotation;

            // Cập nhật xoay của đối tượng
            transform.rotation = newRotation;

            // Cập nhật góc còn lại và thời gian đã xoay
            angleRemaining -= rotationAmount;
            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }


    public void RotateObjectByAngle(float angle)
    {
        StartCoroutine(RotateWoodSmoothly(angle, 60));
    }

    protected override void OnMouseDown()
    {
        if (!isMoved)
        {
            // Di chuyển về vị trí ban đầu
            RotateObjectByAngle(60f);
            isCounterClockwise = true;
            float moveAmount = moveDirection == MoveDirection.Left ? -distanceX : distanceX;
            StartCoroutine(MoveWoodSmoothly(new Vector3(0, -moveAmount, 0f), moveSpeed));
            isMoved = true;
        }
        else
        {
            // Di chuyển theo hướng ban đầu
            RotateObjectByAngle(-60f);
            isCounterClockwise = false;
            float moveAmount = moveDirection == MoveDirection.Left ? -distanceX : distanceX;
            StartCoroutine(MoveWoodSmoothly(new Vector3(0f, moveAmount, 0f), moveSpeed));
            isMoved = false;
        }
    }


    protected override void OnMouseUp()
    {
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);
    }

    private IEnumerator MoveWoodSmoothly(Vector3 moveDistance, float moveSpeed)
    {
        isRotating = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
        Vector3 startPosition = Wood.transform.position;
        Vector3 targetPosition = startPosition + moveDistance;

        float distanceRemaining = moveDistance.magnitude;
        float elapsedTime = 0f;
        while (distanceRemaining > 0.01f)
        {
            // Tính toán vị trí mới dựa trên tốc độ và thời gian
            float step = moveSpeed * Time.deltaTime;
            Vector3 newPosition = Vector3.MoveTowards(Wood.transform.position, targetPosition, step);

            // Cập nhật vị trí của đối tượng
            Wood.transform.position = newPosition;

            // Cập nhật khoảng cách và thời gian đã di chuyển
            float distanceMoved = Vector3.Distance(startPosition, newPosition);
            distanceRemaining = Mathf.Max(0f, moveDistance.magnitude - distanceMoved);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isRotating = false;

        #region Tutorials 2

        if (GameManager.Instance._tutorials._enumTutorials == Ring.Tutorials.EnumTutorials.Step2)
        {
            GameManager.Instance._tutorials._listTutorialUI_2.ForEach(item => item.SetActive(false));
            GameManager.Instance._tutorials._enumTutorials = Ring.Tutorials.EnumTutorials.Step3;
            GameManager.Instance._tutorials.ischeckState = true;
        }

        #endregion
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}