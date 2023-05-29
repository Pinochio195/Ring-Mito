using System;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ring
{
    [Serializable]
    public class Player_Component
    {
        public Rigidbody2D _rigidbody;
        public SkeletonAnimation _skeletonAnimation;
        public Collider _collider;
    }
    [Serializable]
    public class Player_Move
    {
        public float Speed_Move;
        public bool isMovingLeft = false;
        public bool isMovingRight = false;
    }
    [Serializable]
    public class Player_Jump
    {
        public Transform groundCheckTransform; // Đối tượng Transform để chỉ định vị trí bắt đầu của tia
        public float rayDistance = 3f; // Khoảng cách tia bắn xuống dưới
        public bool isCheckGround;
        public bool isCheckOnSpring;
    }
    [Serializable]
    public class TimeToSleep
    {
        public bool isCheckTime;
        public float _timeTouch;
    }
    [Serializable]
    public class Environment_Star
    {
        public Sprite _blackStar;
        public Sprite _yellowStar;
    }
    
    
    
    //UI
    [Serializable]
    public class UI_List
    {
        public List<GameObject> _listStar;
        public List<GameObject> _listButton;
    }
    [Serializable]
    public class Tutorials
    {
        public List<GameObject> _listTutorialUI_1;
        public List<GameObject> _listTutorialUI_2;
        public List<GameObject> _listTutorialUI_3;
        public EnumTutorials _enumTutorials;
        public string _countLevel;
        public bool ischeckState;
        public enum EnumTutorials
        {
            Step1,
            Step2,
            Step3,
            Step4,
            Step5,
            Step6,
            StepEnd
        }
    }
    
}
