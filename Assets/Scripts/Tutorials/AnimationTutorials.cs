using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationTutorials : MonoBehaviour
{
        public Image image;
        public float upDownSpeed = 1f;
        public float upDownDistance = 10f;
    
        private float initialY;
        private bool movingUp = true;
    
        private void Start()
        {
            initialY = image.rectTransform.localPosition.y;
        }
    
        private void Update()
        {
            float newY = image.rectTransform.localPosition.y;
    
            if (movingUp)
            {
                newY += upDownSpeed * Time.deltaTime;
                if (newY >= initialY + upDownDistance)
                {
                    movingUp = false;
                }
            }
            else
            {
                newY -= upDownSpeed * Time.deltaTime;
                if (newY <= initialY - upDownDistance)
                {
                    movingUp = true;
                }
            }
    
            image.rectTransform.localPosition = new Vector3(image.rectTransform.localPosition.x, newY, image.rectTransform.localPosition.z);
        }
}
