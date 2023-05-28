using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusStar : BaseButton
{
    [SerializeField] private GameObject _prefabsStar;
    protected Vector3 targetPosition;
    protected GameObject _star;
    private bool isMoving;
    public float movementSpeed = 5f;
    private int _indexCoin;
    private void Update()
    {
        if (isMoving)
        {
            // Di chuyển đến vị trí B
            _star.transform.position =
                Vector3.MoveTowards(_star.transform.position, targetPosition, movementSpeed * Time.deltaTime);

            // Kiểm tra nếu đã đến vị trí B
            if (_star.transform.position == targetPosition)
            {
                // Biến mất
                Destroy(_star);
                CoinManager.Instance._listCoin[_indexCoin].GetComponent<SpriteRenderer>().color = Color.white;
                isMoving = false;

                #region Tạo tutorial

                if (GameManager.Instance._tutorials._countLevel.Equals("1"))
                {
                    GameManager.Instance._tutorials._listTutorialUI_1.ForEach(item=>item.SetActive(false));
                    if (GameManager.Instance._tutorials._enumTutorials == Ring.Tutorials.EnumTutorials.Step2)
                    {
                        GameManager.Instance._tutorials._enumTutorials = Ring.Tutorials.EnumTutorials.Step3;
                        GameManager.Instance._tutorials.ischeckState = true;
                    }
                }
                
                #endregion
            }
        }
    }

    protected override void OnPress()
    {
        isMoving = true;
        int count = 0;
        for (int i = 0; i < CoinManager.Instance._listCoin.Count; i++)
        {
            if (CoinManager.Instance._listCoin[i].GetComponent<SpriteRenderer>().color != Color.white)
            {
                targetPosition = CoinManager.Instance._listCoin[i].transform.position;
                _indexCoin = i;
                count++;
                break;
            }
        }

        if (count==0)
        {
            for (int i = 0; i < CoinManager.Instance._listCoin.Count; i++)
            {
                if (CoinManager.Instance._listCoin[i] != null)
                {
                    targetPosition = CoinManager.Instance._listCoin[i].transform.position;
                    break;
                }
            }
        }
        _star = Instantiate(_prefabsStar, Camera.main.ScreenToWorldPoint(transform.position), Quaternion.identity);
    }

    protected override void OnRelease()
    {
    }
}