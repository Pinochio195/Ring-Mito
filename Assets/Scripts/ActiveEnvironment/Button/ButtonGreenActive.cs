using System.Collections;
using UnityEngine;

public class ButtonGreenActive : BaseCollider
{
    public float distanceX = 5f;
    public float moveSpeed = 2f; // Tốc độ di chuyển

    private Coroutine moveCoroutine; // Coroutine để di chuyển từ từ
    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private void Start()
    {
        float moveAmount = moveDirection == MoveDirection.Left ? -distanceX : distanceX;
        _startPosition = Wood.transform.position;
        _endPosition = new Vector3(_startPosition.x + moveAmount, _startPosition.y, _startPosition.z);
    }

    private IEnumerator MoveWoodSmoothly(Vector3 moveDistance, float moveSpeed)
    {
        Vector3 startPosition = Wood.transform.position;
        float distance = Vector3.Distance(startPosition, moveDistance);
        float duration = distance / moveSpeed;
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            Wood.transform.position = Vector3.Lerp(startPosition, moveDistance, t);
            yield return null;
        }

        Wood.transform.position = moveDistance;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DisableButton();
            if (Wood != null)
            {
                // Di chuyển theo hướng ban đầu
                StopAllCoroutines();
                EnableButton();
                Vector3 moveDistance = moveDirection == MoveDirection.Left ? _endPosition : _startPosition;
                moveCoroutine = StartCoroutine(MoveWoodSmoothly(_endPosition, moveSpeed));
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnableButton();
            if (Wood != null)
            {
                // Di chuyển về vị trí ban đầu
                DisableButton();
                StopAllCoroutines();
                Vector3 moveDistance = moveDirection == MoveDirection.Left ? _startPosition : _endPosition;
                moveCoroutine = StartCoroutine(MoveWoodSmoothly(_startPosition, moveSpeed));
            }
        }
    }
}