using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BalloonManager : MonoBehaviour, ICollWithPlayer
{
    #region Singleton pattern

    private static BalloonManager instance;

    public static BalloonManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    #endregion

    public GameObject _prefabsBalloon;
    private GameObject _spawnBalloon;
    private bool isCheckBalloon;
    [HideInInspector] public bool isCheckClickDestroyBalloon;
    public float moveSpeed = 5f;

    private Coroutine moveCoroutine;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isCheckClickDestroyBalloon)
        {
            isCheckClickDestroyBalloon = false;
            isCheckBalloon = false;
            LeanPool.Despawn(_spawnBalloon);
            StopMoveCoroutine();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
    }


    public void OnTriggerExit(Collider other)
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            _spawnBalloon = LeanPool.Spawn(_prefabsBalloon, other.transform);
            other.gameObject.transform.SetParent(_spawnBalloon.transform);
            _spawnBalloon.transform.localPosition = new Vector3(0, .35f, 0);
            isCheckBalloon = true;
            moveCoroutine = StartCoroutine(MovePlayerUp(other.gameObject.GetComponent<Rigidbody>()));
            GameManager.Instance._star._listButton.ForEach(item =>
            {
                item.GetComponent<Image>().raycastTarget = false;
            });
        }
    }

    private IEnumerator MovePlayerUp(Rigidbody rb)
    {
        while (isCheckBalloon)
        {
            rb.velocity = Vector3.up * moveSpeed;
            yield return null;
        }

        // Coroutine exited, do any necessary cleanup or logic here
    }

    // Example function to stop the coroutine externally
    public void StopMoveCoroutine()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
    }
}