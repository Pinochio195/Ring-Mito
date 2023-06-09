using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCollider : MonoBehaviour
{
    protected enum MoveDirection { Left, Right }
    [SerializeField] protected GameObject Wood;
    [SerializeField] protected MoveDirection moveDirection = MoveDirection.Left;
    [SerializeField] protected List<GameObject> _listActive;

    protected abstract void OnTriggerEnter(Collider collision);

    protected abstract void OnTriggerExit(Collider collision);

    protected void EnableButton()
    {
        _listActive.ForEach(item =>
        {
            item.transform.GetChild(0).gameObject.SetActive(false);
            item.transform.GetChild(1).gameObject.SetActive(true);
        });
    }
    protected void DisableButton()
    {
        _listActive.ForEach(item=>
        {
            item.transform.GetChild(0).gameObject.SetActive(true);
            item.transform.GetChild(1).gameObject.SetActive(false);
        });
    }
}