using System;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody2D;
    [SerializeField] private BoxCollider _boxCollider;
    public Vector3 targetPosition; // Vị trí B
    public float movementSpeed = 1f; // Tốc độ di chuyển
    private int _indexStar;
    private bool isMoving;

    private void Update()
    {
        if (isMoving)
        {
            // Di chuyển đến vị trí B
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

            // Kiểm tra nếu đã đến vị trí B
            if (transform.position == targetPosition)
            {
                for (int i = 0; i < CoinManager.Instance._listCoin.Count; i++)
                {
                    if (CoinManager.Instance._listCoin[i].name.Equals(gameObject.name))
                    {
                        CoinManager.Instance._listCoin.RemoveAt(i);
                    }
                }
                // Biến mất
                GameManager.Instance._star._listStar[_indexStar].GetComponent<Image>().sprite = GameManager.Instance._prefabsEnvironment._yellowStar;
                Destroy(gameObject);
                isMoving = false;
            }
        }
    }
    private void OnMouseDown()
    {
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.position = transform.position;

        #region Tạo Tutorial
        if (GameManager.Instance._tutorials._countLevel.Equals("1"))
        {
            GameManager.Instance._tutorials._listTutorialUI_1.ForEach(item=>item.SetActive(false));
            if (GameManager.Instance._tutorials._enumTutorials == Ring.Tutorials.EnumTutorials.Step1)
            {
                GameManager.Instance._tutorials._enumTutorials = Ring.Tutorials.EnumTutorials.Step2;
                GameManager.Instance._tutorials.ischeckState = true;
            }
            else if (GameManager.Instance._tutorials._enumTutorials == Ring.Tutorials.EnumTutorials.Step3)
            {
                GameManager.Instance._tutorials._enumTutorials = Ring.Tutorials.EnumTutorials.Step4;
                GameManager.Instance._tutorials.ischeckState = true;
            }
        }
        #endregion
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i <  GameManager.Instance._star._listStar.Count; i++)
            {
                if (!GameManager.Instance._star._listStar[i].GetComponent<StarInUi>().isCheck)
                {
                    targetPosition = Camera.main.ScreenToWorldPoint(GameManager.Instance._star._listStar[i].gameObject.transform.position);
                    GameManager.Instance._star._listStar[i].GetComponent<StarInUi>().isCheck = true;
                    _indexStar = i;
                    break;
                }
            }
            _rigidbody2D.isKinematic = true;
            _boxCollider.enabled = false;
            isMoving = true;
        }
    }
}
