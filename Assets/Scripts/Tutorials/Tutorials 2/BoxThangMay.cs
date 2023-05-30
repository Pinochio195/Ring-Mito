using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxThangMay : MonoBehaviour
{
    [SerializeField] private Collider _boxStep3;
    [SerializeField] private Collider _collider;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance._tutorials._enumTutorials == Ring.Tutorials.EnumTutorials.Step1)
            {
                GameManager.Instance._tutorials._listTutorialUI_2.ForEach(item=>item.SetActive(false));
                GameManager.Instance._tutorials._enumTutorials = Ring.Tutorials.EnumTutorials.Step2;
                GameManager.Instance._tutorials.ischeckState = true;
                _collider.enabled = false;//Tắt đi để tránh lại va chạm

            }
            else if (GameManager.Instance._tutorials._enumTutorials == Ring.Tutorials.EnumTutorials.Step3)
            {
                GameManager.Instance._tutorials._listTutorialUI_2.ForEach(item=>item.SetActive(false));
                GameManager.Instance._tutorials._enumTutorials = Ring.Tutorials.EnumTutorials.Step4;
                _boxStep3.enabled = true;
                GameManager.Instance._tutorials.ischeckState = true;
                _collider.enabled = false;//Tắt đi để tránh lại va chạm
            }
            else if (GameManager.Instance._tutorials._enumTutorials == Ring.Tutorials.EnumTutorials.Step4)
            {
                GameManager.Instance._tutorials._listTutorialUI_2.ForEach(item=>item.SetActive(false));
                GameManager.Instance._tutorials._enumTutorials = Ring.Tutorials.EnumTutorials.Step5;
                GameManager.Instance._tutorials.ischeckState = true;
                _collider.enabled = false;//Tắt đi để tránh lại va chạm
            }
           
            Debug.Log(GameManager.Instance._tutorials._enumTutorials);
        }
    }
}
