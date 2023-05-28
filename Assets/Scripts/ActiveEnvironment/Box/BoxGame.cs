using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class BoxGame : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation _skeletonAnimation;
    private void Start()
    {
        _skeletonAnimation.AnimationName = "close";
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _skeletonAnimation.AnimationName = "open";
            StartCoroutine(DelayWin());
            GameManager.Instance._star._listButton.ForEach(item=>item.SetActive(false));
            PlayerController.Instance._playerComponent._skeletonAnimation.AnimationName = "happy";

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

    IEnumerator DelayWin()
    {
        yield return new WaitForSeconds(1f);
        _skeletonAnimation.AnimationName = "idle";
    }
}
