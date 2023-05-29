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
                if (GameManager.Instance._tutorials._countLevel.Equals("1"))
                {
                    GameManager.Instance._tutorials._listTutorialUI_1[0].SetActive(true);
                }
                else if(GameManager.Instance._tutorials._countLevel.Equals("2"))
                {
                    GameManager.Instance._tutorials._listTutorialUI_2[0].SetActive(true);
                }
                else if(GameManager.Instance._tutorials._countLevel.Equals("3"))
                {
                    GameManager.Instance._tutorials._listTutorialUI_3[0].SetActive(true);
                }
                GameManager.Instance._tutorials.ischeckState = false;
                break;

            case Ring.Tutorials.EnumTutorials.Step2:
                if (GameManager.Instance._tutorials._countLevel.Equals("1"))
                {
                    GameManager.Instance._tutorials._listTutorialUI_1[1].SetActive(true);
                }
                else
                {
                    GameManager.Instance._tutorials._listTutorialUI_2[1].SetActive(true);
                }

                GameManager.Instance._tutorials.ischeckState = false;
                break;

            case Ring.Tutorials.EnumTutorials.Step3:
                if (GameManager.Instance._tutorials._countLevel.Equals("1"))
                {
                    GameManager.Instance._tutorials._listTutorialUI_1[2].SetActive(true);
                }
                else
                {
                    GameManager.Instance._tutorials._listTutorialUI_2[2].SetActive(true);
                }

                GameManager.Instance._tutorials.ischeckState = false;
                break;
            case Ring.Tutorials.EnumTutorials.Step4:
                if (GameManager.Instance._tutorials._countLevel.Equals("1"))
                {
                    GameManager.Instance._tutorials._listTutorialUI_1[3].SetActive(true);
                }
                else
                {
                    GameManager.Instance._tutorials._listTutorialUI_2[3].SetActive(true);
                }

                GameManager.Instance._tutorials.ischeckState = false;
                break;
            case Ring.Tutorials.EnumTutorials.Step5:
                GameManager.Instance._tutorials._listTutorialUI_2[4].SetActive(true);
                GameManager.Instance._tutorials.ischeckState = false;
                break;
            case Ring.Tutorials.EnumTutorials.Step6:
                GameManager.Instance._tutorials._listTutorialUI_2[5].SetActive(true);
                GameManager.Instance._tutorials.ischeckState = false;
                break;
            case Ring.Tutorials.EnumTutorials.StepEnd:
                if (GameManager.Instance._tutorials._countLevel.Equals("1"))
                {
                    GameManager.Instance._tutorials._listTutorialUI_1.ForEach(item => item.SetActive(false));
                }
                else if (GameManager.Instance._tutorials._countLevel.Equals("2"))
                {
                    GameManager.Instance._tutorials._listTutorialUI_2.ForEach(item => item.SetActive(false));
                    
                }
                else
                {
                    GameManager.Instance._tutorials._listTutorialUI_3.ForEach(item => item.SetActive(false));
                }
              

                GameManager.Instance._tutorials.ischeckState = false;
                break;
            default:
                break;
        }
    }
}