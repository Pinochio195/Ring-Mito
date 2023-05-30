using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class BoxGame : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation _skeletonAnimation;
    private TrackEntry _currentAnimationTrackEntry;

    private void Start()
    {
        _skeletonAnimation.AnimationName = "close";
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DelayAnimations());
            GameManager.Instance._star._listButton.ForEach(item=>item.SetActive(false));

            #region Ngăn velocity chạy

            PlayerController.Instance._playerMove.isMovingRight = false;
            PlayerController.Instance._playerMove.isMovingLeft = false;

            #endregion
        }
        #region Tutorials

        if (GameManager.Instance._tutorials._enumTutorials == Ring.Tutorials.EnumTutorials.Step6)
        {
            GameManager.Instance._tutorials._enumTutorials = Ring.Tutorials.EnumTutorials.StepEnd;
            GameManager.Instance._tutorials.ischeckState = true;
        }

        #endregion
    }

    IEnumerator DelayAnimations()
    {
        PlayerController.Instance._sleepTime.isCheckTime = false;//ngưng ko cho player sleep nữa 
        // Đặt animation "skill"
        PlayerController.Instance._playerComponent._skeletonAnimation.AnimationName = "skill";

        // Đăng ký sự kiện Complete để kiểm tra khi animation "skill" kết thúc
        _currentAnimationTrackEntry = PlayerController.Instance._playerComponent._skeletonAnimation.state.GetCurrent(0);
        _currentAnimationTrackEntry.Complete += OnSkillAnimationComplete;

        // Chờ đến khi animation "skill" kết thúc
        yield return new WaitUntil(() => _currentAnimationTrackEntry.IsComplete);

        // Gỡ bỏ sự kiện Complete
        _currentAnimationTrackEntry.Complete -= OnSkillAnimationComplete;

        // Đặt animation "happy"
        PlayerController.Instance._playerComponent._skeletonAnimation.AnimationName = "happy";
        _skeletonAnimation.AnimationName = "open";

        // Đặt animation "idle" của BoxGame sau 1 giây nữa
        yield return new WaitForSeconds(1f);
        _skeletonAnimation.AnimationName = "idle";
    }

    private void OnSkillAnimationComplete(TrackEntry trackEntry)
    {
        // Animation "skill" đã kết thúc
        Debug.Log("Animation 'skill' đã kết thúc");
    }
}
