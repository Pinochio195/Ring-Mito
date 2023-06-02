using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mushroom : MonoBehaviour
{
    private bool isCheckMove;
    public float _speed;
    [SerializeField] private SkeletonAnimation _skeletonAnimation;

    public void EnableFan()
    {
        isCheckMove = true;
    }

    public void DisableFan()
    {
        isCheckMove = false;
        _skeletonAnimation.AnimationName = "idle";
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && isCheckMove)
        {
            #region Xử lí sự kiện animation

            if (_skeletonAnimation.AnimationName.Equals("idle"))
            {
                PlayAnimation("idle2spin", () => { _skeletonAnimation.AnimationName = "spin"; }, false);
            }

            #endregion
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isCheckMove)
        {
            // Kiểm tra xem đối tượng có tên được hiển thị hay không
            bool displayNames = other.gameObject.CompareTag("Player2");

            Vector3 _directionMushroom =
                (other.gameObject.transform.position - gameObject.transform.position).normalized;
            if (displayNames)
            {
                // Xác định tất cả các đối tượng trong box trigger
                Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(1f, 1f, 1f) / 2f);

                // Hiển thị tên của các đối tượng
                foreach (Collider collider in colliders)
                {
                    Debug.Log(other.gameObject.name);
                    //Player hoặc player 2
                    other.gameObject.transform.Translate(_directionMushroom*.125f*Time.deltaTime);
                }
            }
            else
            {
                Debug.Log(other.gameObject.name);
                //các object khác
                other.gameObject.GetComponent<Rigidbody>().velocity = _directionMushroom * this._speed * Time.deltaTime;
                other.gameObject.transform.Rotate(Vector3.forward * _directionMushroom.magnitude * 90 * Time.deltaTime);
            }
        }
    }

    private void PlayAnimation(string animationName, Action onAnimationComplete = null, bool loop = true)
    {
        _skeletonAnimation.AnimationName = animationName;
        var trackEntry = _skeletonAnimation.state.GetCurrent(0);
        trackEntry.Loop = loop;
        trackEntry.Complete += (entry) => { onAnimationComplete?.Invoke(); };
    }
}