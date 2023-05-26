using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    private static GameManager instance;

    // Singleton accessor
    public static GameManager Instance
    {
        get { return instance; }
    }
    [Space(10)] [HeaderTextColor(0.6f, 0.6f, 1, headerText = "_star")]
    public Ring.UI_List _star;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
