using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    #region Singleton

    // Singleton instance
    private static GameManager instance;

    // Singleton accessor
    public static GameManager Instance
    {
        get { return instance; }
    }

    #endregion

    [Space(10)] [HeaderTextColor(0.6f, 0.6f, 1, headerText = "Star")]
    public Ring.UI_List _star;

    [Space(10)] [HeaderTextColor(0.6f, 0.6f, 1, headerText = "Tutorials")]
    public Ring.Tutorials _tutorials;
    [FormerlySerializedAs("prefabsEnvironment")] [FormerlySerializedAs("_environmentStar")] [Space(10)] [HeaderTextColor(0.6f, 0.6f, 1, headerText = "Environmant - star")]
    public Ring.Prefabs_Environment _prefabsEnvironment;

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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        #region Tutorials

        _tutorials._countLevel = scene.name;
        if (scene.name.Equals("1"))
        {
            _tutorials._listTutorialUI_1.ForEach(item => item.SetActive(false));
            _tutorials._enumTutorials = Ring.Tutorials.EnumTutorials.Step1;
            _tutorials.ischeckState = true;
        }
        else if (scene.name.Equals("2"))
        {
            _tutorials._enumTutorials = Ring.Tutorials.EnumTutorials.Step1;
        }
        else if (scene.name.Equals("3"))
        {
            _tutorials._enumTutorials = Ring.Tutorials.EnumTutorials.Step1;
        }

        #endregion
    }

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Tutorials_1()
    {
    }
}