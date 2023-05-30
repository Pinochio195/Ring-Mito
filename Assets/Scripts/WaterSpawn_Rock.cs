using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawn_Rock : MonoBehaviour
{
    #region Singleton

    // Singleton instance
    private static WaterSpawn_Rock instance;

    // Singleton accessor
    public static WaterSpawn_Rock Instance
    {
        get { return instance; }
    }

    #endregion
    public List<GameObject> _listObjectLava;
    public List<GameObject> _listObjectWater;
    public bool isCheckTouchLava;
    [Range(0,2)]public float _randomSpawn;
    private void Awake()
    {
        // Ensure only one instance of the player exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
}
