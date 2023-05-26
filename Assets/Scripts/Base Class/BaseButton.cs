using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    protected bool isPressed = false;
    [SerializeField]protected Button button;

    protected virtual void Awake()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        OnPress();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        OnRelease();
    }
    protected abstract void OnPress();
    protected abstract void OnRelease();
    
}