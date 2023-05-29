using UnityEngine;

public class ObjectPositionMatcher : MonoBehaviour
{
    public GameObject targetObject; // Đối tượng đầu vào
    public Vector2 _transformObject;
    private void Start()
    {
        // Chuyển vị trí của đối tượng sang vị trí trên màn hình
        Vector3 objectScreenPosition = Camera.main.WorldToScreenPoint(targetObject.transform.position);

        // Gán vị trí của RectTransform bằng vị trí trên màn hình của đối tượng
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.position = new Vector2(_transformObject.x+objectScreenPosition.x , _transformObject.y+objectScreenPosition.y);
    }
}