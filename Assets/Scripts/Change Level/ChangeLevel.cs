using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : BaseButton
{
    public LevelSelection levelSelection;
    public enum LevelSelection
    {
        Level1,
        Level2
    }

    protected override void OnPress()
    {
        string sceneName = GetSceneName(levelSelection); // Lấy tên cảnh từ enum

        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName); // Tải cảnh theo tên được lấy từ enum
        }
        else
        {
            Debug.LogWarning("Invalid level selection!"); // Cảnh bị thiếu hoặc không hợp lệ
        }
    }

    protected override void OnRelease()
    {
        
    }
    string GetSceneName(LevelSelection selection)
    {
        switch (selection)
        {
            case LevelSelection.Level1:
                return "1"; // Tên cảnh của Level 1

            case LevelSelection.Level2:
                return "2"; // Tên cảnh của Level 2
            
            default:
                return null; // Trường hợp không hợp lệ
        }
    }
}
