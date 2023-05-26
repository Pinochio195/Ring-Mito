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
    }
    [Serializable]
    public class Player_Move
    {
        public float Speed_Move;
        public bool isMovingLeft = false;
        public bool isMovingRight = false;
    }
    [Serializable]
    public class TimeToSleep
    {
        public bool isCheckTime;
        public float _timeTouch;
    }
    [Serializable]
    public class Environment_PlusStar
    {
        public GameObject _blackStar;
        public GameObject _yellowStar;
        public Transform _spawnStar;
    }
    
    
    
    //UI
    [Serializable]
    public class UI_List
    {
        public List<GameObject> _listStar;
        public List<GameObject> _listButton;
        
    }
    
}
