using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaterSpawn : MonoBehaviour
{
    private void Start()
    {
    }

    private void OnEnable()
    {
        //Keysave.ac_SoundWaterOff += OffSoundWater;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            WaterSpawn_Rock.Instance._listObjectLava.ForEach(item => item.SetActive(false));
            if (!WaterSpawn_Rock.Instance.isCheckTouchLava)
            {
                WaterSpawn_Rock.Instance.isCheckTouchLava = true;
                GameObject _water;
                for (int i = 0; i < 10; i++)
                {
                    Instantiate(GameManager.Instance._prefabsEnvironment._rock,
                        new Vector2(
                            transform.position.x + Random.Range(-WaterSpawn_Rock.Instance._randomSpawn,
                                WaterSpawn_Rock.Instance._randomSpawn), transform.position.y),
                        Quaternion.identity);
                }
                if (WaterSpawn_Rock.Instance._listObjectWater.Count > 0)
                {
                    StartCoroutine(DelayDisable());
                }
                else
                {
                    if (PlayerController2.Instance._waterGameObject.activeSelf)
                    {
                        //StartCoroutine(DelayGameObject());
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnTriggerExit(Collider collision)
    {
        /*if (collision.CompareTag("Lava"))
        {
            if (!WaterSpawn_Rock.Instance.isCheckTouchLava)
            {
                WaterSpawn_Rock.Instance.isCheckTouchLava = true;
                StartCoroutine(DelayDisable());
                for (int i = 0; i < 10; i++)
                {
                    Instantiate(GameManager.Instance._prefabsEnvironment._rock, new Vector2(transform.position.x+Random.Range(-WaterSpawn_Rock.Instance._randomSpawn,WaterSpawn_Rock.Instance._randomSpawn),transform.position.y),
                        Quaternion.identity);
                }
            }
        }*/
    }

    IEnumerator DelayDisable()
    {
        yield return new WaitForSeconds(1.5f);
        WaterSpawn_Rock.Instance._listObjectWater.ForEach(item => item.SetActive(false));
    }
    IEnumerator DelayGameObject()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerController2.Instance._waterGameObject.SetActive(false);
    }
}