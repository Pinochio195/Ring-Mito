using System;
 using UnityEngine;
 
 public class SteeringWheelRotation : MonoBehaviour
 {
     #region Singleton Pattern
 
     // Singleton instance
     private static SteeringWheelRotation instance;
 
     // Singleton accessor
     public static SteeringWheelRotation Instance
     {
         get { return instance; }
     }
 
     #endregion
     public GameObject objectToMove;
     public float moveSpeed = 1f;
     private bool isDragging = false;
     private Vector2 previousPosition;
     public bool isRotating;//cho raw xoay theo vòng quay
     public bool isCounterClockwise;//cho raw xoay theo vòng quay
     public float _heightMax;
     private Vector2 _maxHeight;
     private Vector2 _minHeight;
     private void Awake()
     {
         // Ensure only one instance of the player exists
         if (instance != null && instance != this)
         {
             Destroy(gameObject);
             return;
         }
 
         instance = this;
     }
     private void OnMouseDown()
     {
         isDragging = true;
         previousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
     }
 
     private void Start()
     {
         _minHeight = objectToMove.transform.position;
         _maxHeight = new Vector2(_minHeight.x, _minHeight.y + _heightMax);
     }
 
     private void OnMouseUp()
     {
         isDragging = false;
         isRotating = false;
     }
 
     private void OnMouseDrag()
     {
         if (isDragging)
         {
             Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             float angle = Vector2.SignedAngle(previousPosition - (Vector2)transform.position, currentPosition - (Vector2)transform.position);
             transform.Rotate(Vector3.forward, angle-(angle*.5f));
             previousPosition = currentPosition;
 
             // Di chuyển object A
             float moveAmount = angle *Time.deltaTime * moveSpeed*0.001f;
             Vector3 moveDirection = moveAmount > 0 ? Vector3.up : Vector3.down;
             //isCounterClockwise
             isCounterClockwise = (moveDirection == Vector3.up);
             isRotating = true;
             if ((objectToMove.transform.position.y <= _maxHeight.y && moveDirection == Vector3.up) || (objectToMove.transform.position.y >= _minHeight.y && moveDirection == Vector3.down))
             {
                objectToMove.transform.Translate(moveDirection * Mathf.Abs(moveAmount));
             }
         }
     }
 }