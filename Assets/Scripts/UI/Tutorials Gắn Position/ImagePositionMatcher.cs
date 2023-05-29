using UnityEngine;
using UnityEngine.UI;

public class ImagePositionMatcher : MonoBehaviour
{
    public Image targetImage; // Image đầu vào

    private void Start()
    {
        // Gán vị trí của image gắn script trùng với vị trí của targetImage
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.position = targetImage.rectTransform.position;
    }
}