using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : BaseTouch
{
    public float distanceX = 5f;
    public float moveSpeed = 2f; // Tốc độ di chuyển
    private Coroutine moveCoroutine; // Coroutine để di chuyển từ từ
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private bool isMoved; // Trạng thái đã di chuyển
    public Vector2 _force;
    

    protected override void OnMouseDown()
    {
        float moveAmount = moveDirection == MoveDirection.Left ? -distanceX : distanceX;
        if (!isMoved)
        {
            StartCoroutine(MoveWoodSmoothly(new Vector3(0f, moveAmount, 0f), moveSpeed));
        }
        else
        {
            StartCoroutine(MoveWoodSmoothly(new Vector3(0f, -moveAmount, 0f), moveSpeed));
        }

        #region Tutorials

        if (GameManager.Instance._tutorials._enumTutorials == Ring.Tutorials.EnumTutorials.Step5)
        {
            GameManager.Instance._tutorials._listTutorialUI_2.ForEach(item=>item.SetActive(false));
            GameManager.Instance._tutorials._enumTutorials = Ring.Tutorials.EnumTutorials.Step6;
            GameManager.Instance._tutorials.ischeckState = true;
        }

        #endregion
    }

    protected override void OnMouseUp()
    {
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);
    }

    private IEnumerator MoveWoodSmoothly(Vector3 moveDistance, float moveSpeed)
    {
        gameObject.GetComponent<Collider>().enabled = false;
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

            if (PlayerController.Instance._playerJump.isCheckOnSpring)
            {
                PlayerController.Instance._playerComponent._rigidbody.velocity = new Vector2((PlayerController.Instance._playerComponent._skeletonAnimation.skeleton.ScaleX > 0 ? _force.x : -_force.x),_force.y);
            }
            yield return null;
        }

        yield return new WaitForSeconds(.05f);
        if (!isMoved)
        {
            isMoved = true;
            _startPosition = Wood.transform.position;
            _endPosition = startPosition;
            targetPosition = _endPosition;
            startPosition = _startPosition;
            moveDistance = _endPosition - _startPosition;

            float distanceRemainingBack = moveDistance.magnitude;
            elapsedTime = 0f;
            while (distanceRemainingBack > 0.01f)
            {
                // Tính toán vị trí mới dựa trên tốc độ và thời gian
                float step = moveSpeed * Time.deltaTime;
                Vector3 newPosition = Vector3.MoveTowards(Wood.transform.position, targetPosition, step);

                // Cập nhật vị trí của đối tượng
                Wood.transform.position = newPosition;

                // Cập nhật khoảng cách và thời gian đã di chuyển
                float distanceMoved = Vector3.Distance(startPosition, newPosition);
                distanceRemainingBack = Mathf.Max(0f, moveDistance.magnitude - distanceMoved);
                elapsedTime += Time.deltaTime;

                yield return null;
            }
            isMoved = false;
        }

        gameObject.GetComponent<Collider>().enabled = true;
    }
}
