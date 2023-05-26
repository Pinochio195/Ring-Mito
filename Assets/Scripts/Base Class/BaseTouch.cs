using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTouch : MonoBehaviour
{
    public enum MoveDirection { Left, Right }
    [SerializeField]protected GameObject Wood;
    [SerializeField] protected MoveDirection moveDirection = MoveDirection.Left;
    [SerializeField] protected List<GameObject> _listActive;
    protected abstract void OnMouseDown();

    protected abstract void OnMouseUp();

    protected void EnableButton()
    {
        _listActive.ForEach(item=>
        {
            item.transform.GetChild(0).gameObject.SetActive(true);
            item.transform.GetChild(1).gameObject.SetActive(false);
        });
    }
    protected void DisableButton()
    {
        _listActive.ForEach(item=>
        {
            item.transform.GetChild(0).gameObject.SetActive(false);
            item.transform.GetChild(1).gameObject.SetActive(true);
        });
    }

    private void OnMouseDownEvent()
    {
        OnMouseDown();
    }

    private void OnMouseUpEvent()
    {
        OnMouseUp();
    }
}