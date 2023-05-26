using System.Collections;
using UnityEngine;

public class ButtonRedActive : BaseTouch
{
    public float distanceX = 5f;
    public float moveSpeed = 2f; // Tốc độ di chuyển

    private Coroutine moveCoroutine; // Coroutine để di chuyển từ từ
    private bool isMoved = false; // Trạng thái đã di chuyển

    protected override void OnMouseDown()
    {
        if (Wood != null)
        {
            if (isMoved)
            {
                // Di chuyển về vị trí ban đầu
                DisableButton();
                float moveAmount = moveDirection == MoveDirection.Left ? -distanceX : distanceX;
                StartCoroutine(MoveWoodSmoothly(new Vector3(-moveAmount, 0f, 0f), moveSpeed));
                isMoved = false;
            }
            else
            {
                // Di chuyển theo hướng ban đầu
                EnableButton();
                float moveAmount = moveDirection == MoveDirection.Left ? -distanceX : distanceX;
                StartCoroutine(MoveWoodSmoothly(new Vector3(moveAmount, 0f, 0f), moveSpeed));
                isMoved = true;
            }
        }
    }


    protected override void OnMouseUp()
    {
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);
    }

    private IEnumerator MoveWoodSmoothly(Vector3 moveDistance, float moveSpeed)
    {
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
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
  
}
