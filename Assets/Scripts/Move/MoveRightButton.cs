using UnityEngine;

public class MoveRightButton : BaseButton
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
        // Di chuyển Player sang phải khi nút được nhấn và giữ
        if (PlayerController2.Instance != null)
        {
            
        if (PlayerController.Instance.enabled&&!PlayerController2.Instance.enabled)
        {
            PlayerController.Instance.StartMovingRight();
        }

        if (PlayerController2.Instance.enabled&&!PlayerController.Instance.enabled)
        {
            PlayerController2.Instance.StartMovingRight();
        }
        }
        else
        {
            PlayerController.Instance.StartMovingRight();
        }
    }

    protected override void OnRelease()
    {
        if (PlayerController2.Instance != null)
        {
            // Dừng di chuyển Player sang phải khi nút được nhả
            if (PlayerController.Instance.enabled && !PlayerController2.Instance.enabled)
            {
                PlayerController.Instance.StopMovingRight();
            }

            if (PlayerController2.Instance.enabled && !PlayerController.Instance.enabled)
            {
                PlayerController2.Instance.StopMovingRight();
            }
        }
        else
        {
            PlayerController.Instance.StopMovingRight();
        }
    }
}