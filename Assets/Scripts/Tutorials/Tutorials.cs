using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorials : MonoBehaviour
{
    private void Start()
    {
        ChangeState();
    }

    private void Update()
    {
        if (GameManager.Instance._tutorials.ischeckState)
        {
            ChangeState();
        }
    }

    void ChangeState()
    {
        switch (GameManager.Instance._tutorials._enumTutorials)
        {
            case Ring.Tutorials.EnumTutorials.Step1:
                GameManager.Instance._tutorials._listTutorialUI_1[0].SetActive(true);
                GameManager.Instance._tutorials.ischeckState = false;
                break;

            case Ring.Tutorials.EnumTutorials.Step2:
                GameManager.Instance._tutorials._listTutorialUI_1[1].SetActive(true);
                GameManager.Instance._tutorials.ischeckState = false;
                break;

            case Ring.Tutorials.EnumTutorials.Step3:
                GameManager.Instance._tutorials._listTutorialUI_1[2].SetActive(true);
                GameManager.Instance._tutorials.ischeckState = false;
                break;
            case Ring.Tutorials.EnumTutorials.Step4:
                GameManager.Instance._tutorials._listTutorialUI_1[3].SetActive(true);
                GameManager.Instance._tutorials.ischeckState = false;
                break;
            case Ring.Tutorials.EnumTutorials.StepEnd:
                GameManager.Instance._tutorials._listTutorialUI_1.ForEach(item=>item.SetActive(false));
                GameManager.Instance._tutorials.ischeckState = false;
                break;
            default:
                break;
            
        }
    }
}