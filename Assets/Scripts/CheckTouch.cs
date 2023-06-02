using System;
using System.Collections;
using System.Collections.Generic;
using Ring;
using UnityEngine;

public class CheckTouch : MonoBehaviour
{
    public Player_Touch _playerTouch;

    public enum Gender
    {
        Boy,
        Girl
    }

    public Gender _gender = Gender.Boy;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        Debug.Log(123);
        if (_gender == Gender.Girl)
        {
        Debug.Log(1);
            if (_playerTouch._boyController.enabled)
            {
                _playerTouch._boyController.enabled = false;
            }

            _playerTouch._girlController.enabled = true;
            _playerTouch._boyController.gameObject.transform.Find("Arrow").gameObject.SetActive(false);
            _playerTouch._girlController.gameObject.transform.Find("Arrow").gameObject.SetActive(true);
        }
        else
        {
            if (_playerTouch._girlController != null && _playerTouch._boyController != null)
            {
                if (_playerTouch._girlController.enabled)
                {
                    _playerTouch._girlController.enabled = false;
                }

                _playerTouch._boyController.enabled = true;
                _playerTouch._girlController.gameObject.transform.Find("Arrow").gameObject.SetActive(false);
                _playerTouch._boyController.gameObject.transform.Find("Arrow").gameObject.SetActive(true);
            }
        }
    }
}