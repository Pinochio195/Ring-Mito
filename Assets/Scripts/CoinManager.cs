using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    // Singleton instance
    private static CoinManager instance;

    // Singleton accessor
    public static CoinManager Instance
    {
        get { return instance; }
    }

    [SerializeField] public List<GameObject> _listCoin;
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
