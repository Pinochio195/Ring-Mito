using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseObjectMovement : MonoBehaviour
{
    public AudioSource _audio;
    public List<Transform> _listTargetTransforms; // Danh sách các transform mục tiêu
    public float speed = 3f; // Tốc độ di chuyển của object
    protected int currentTargetIndex = 0; // Chỉ số của transform hiện tại trong danh sách
    public bool isCheckMove;
    public bool isCheckClick;
    
    public virtual void Update()
    {
        if (isCheckMove)
        {
            // Kiểm tra nếu object đã đến được transform cuối cùng
            if (currentTargetIndex >= _listTargetTransforms.Count )
            {
                // Dừng di chuyển
                _listTargetTransforms.Reverse();
                currentTargetIndex = 0;
                isCheckMove = false;
                isCheckClick = false;
                _audio.Stop();
                return;
            }

            // Lấy transform mục tiêu hiện tại
            Transform targetTransform = _listTargetTransforms[currentTargetIndex];

            // Di chuyển object tới transform mục tiêu
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, step);

            // Kiểm tra nếu object đã đến gần đủ transform mục tiêu
            if (Vector3.Distance(transform.position, targetTransform.position) < 0.001f)
            {
                // Di chuyển đến transform tiếp theo trong danh sách
                currentTargetIndex++;
            }
        }
    }

    public virtual void OnMouseDown()
    {
        if (!isCheckClick)
        {
            _audio.Play();
            isCheckMove = true;
            isCheckClick = true;
        }
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        other.transform.SetParent(gameObject.transform);
    }
}