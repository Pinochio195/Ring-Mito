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
        PlayerController.Instance.StartMovingRight();
    }

    protected override void OnRelease()
    {
        // Dừng di chuyển Player sang phải khi nút được nhả
        PlayerController.Instance.StopMovingRight();
    }
}
