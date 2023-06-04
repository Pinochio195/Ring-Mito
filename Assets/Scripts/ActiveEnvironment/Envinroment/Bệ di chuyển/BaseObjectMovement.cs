using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseObjectMovement : MonoBehaviour
{
    public AudioSource _audio;
    [SerializeField] protected List<Transform> _listTargetTransforms; // Danh sách các transform mục tiêu
    protected List<Transform> _listTargetOriginal; // Danh sách các transform mục tiêu
    private bool isCheckListQeque;
    public float speed = 3f; // Tốc độ di chuyển của object
    [SerializeField] protected int currentTargetIndex = 0; // Chỉ số của transform hiện tại trong danh sách
    public bool isCheckMove;
    public bool isCheckClick;
    protected bool isCheckReverse;

    public virtual void Start()
    {
        _listTargetOriginal = new List<Transform>(_listTargetTransforms);
    }

    public virtual void Update()
    {
        if (isCheckMove)
        {
            // Kiểm tra nếu object đã đến được transform cuối cùng
            if (currentTargetIndex >= _listTargetTransforms.Count)
            {
                // Dừng di chuyển
                _listTargetTransforms.Reverse();
                isCheckReverse = true;
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
        _audio.Play();
        if (!isCheckClick)
        {
            isCheckMove = true;
            isCheckClick = true;
        }
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        other.transform.SetParent(gameObject.transform);
    }
}