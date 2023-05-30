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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Lava"))
        {
            WaterSpawn_Rock.Instance._listObjectLava.ForEach(item => item.SetActive(false));
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
        }
    }

    IEnumerator DelayDisable()
    {
        yield return new WaitForSeconds(.75f);
        WaterSpawn_Rock.Instance._listObjectWater.ForEach(item => item.SetActive(false));
    }
}