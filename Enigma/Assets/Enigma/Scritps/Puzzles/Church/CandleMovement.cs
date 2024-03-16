using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandleMovement : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Button rightArrow, leftArrow, upArrow, downArrow;
    [SerializeField] List<GameObject> candles;
    GameObject currCandle;

    [SerializeField] float maxWidthX, maxHeightY;

    private void Start()
    {
        rightArrow.onClick.AddListener(() => MoveCandle(Vector2.right));
        leftArrow.onClick.AddListener(() => MoveCandle(Vector2.left));
        upArrow.onClick.AddListener(() => MoveCandle(Vector2.up));
        downArrow.onClick.AddListener(() => MoveCandle(Vector2.down));
        currCandle = candles[0];
    }

    private void Update()
    {
        GetCollision();
    }
    private void GetCollision()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(mousePosition);

            RaycastHit2D raycast2D = Physics2D.GetRayIntersection(ray);

            if (raycast2D.collider && raycast2D.collider.gameObject.CompareTag("Candle"))
            {
                Debug.Log(currCandle);
                currCandle = raycast2D.collider.gameObject;
            }
        }
    }

    private void MoveCandle(Vector2 _direction)
    {
        currCandle.transform.Translate(_direction);
        foreach(GameObject candle in candles)
        {
            if (candle == currCandle) continue;
            else
            {
                if (candle.transform.position == currCandle.transform.position) 
                {
                    currCandle.transform.Translate(-_direction);
                    break;
                }
            }
        }

        if (currCandle.gameObject.transform.position.x < -maxWidthX ||
            currCandle.gameObject.transform.position.x > maxWidthX ||
            currCandle.gameObject.transform.position.y < -maxHeightY ||
            currCandle.gameObject.transform.position.y > maxHeightY)
        {
            currCandle.transform.Translate(-_direction);
        }
    }

    public List<GameObject> GetCandlesPosition()
    {
        return candles;
    }

}
