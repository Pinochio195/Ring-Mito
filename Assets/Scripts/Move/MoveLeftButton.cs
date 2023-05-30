using System.Collections;
using System.Collections.Generic;
using Ring;
using UnityEngine;

public class MoveLeftButton : BaseButton
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected override void OnPress()
    {
        // Di chuyển Player sang trái khi nút được nhấn và giữ
        if (PlayerController.Instance.enabled&&!PlayerController2.Instance.enabled)
        {
            PlayerController.Instance.StartMovingLeft();
        }

        if (PlayerController2.Instance.enabled&&!PlayerController.Instance.enabled)
        {
            PlayerController2.Instance.StartMovingLeft();
        }
    }

    protected override void OnRelease()
    {
        // Dừng di chuyển Player sang trái khi nút được nhả
        if (PlayerController.Instance.enabled&&!PlayerController2.Instance.enabled)
        {
            PlayerController.Instance.StopMovingLeft();
        }

        if (PlayerController2.Instance.enabled&&!PlayerController.Instance.enabled)
        {
            PlayerController2.Instance.StopMovingLeft();
        }
    }
}