using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandleMovement : MonoBehaviour
{
    Camera cam;
    [SerializeField] Button rightArrow, leftArrow, upArrow, downArrow;
    [SerializeField] List<GameObject> candles;
    GameObject currCandle;

    int minX = 100, minY = 100, maxX = 1800, maxY = 800;

    private void Start()
    {
        cam = Camera.main;
        rightArrow.onClick.AddListener(() => MoveCandle(Vector2.right * 100));
        leftArrow.onClick.AddListener(() => MoveCandle(Vector2.left * 100));
        upArrow.onClick.AddListener(() => MoveCandle(Vector2.up * 100));
        downArrow.onClick.AddListener(() => MoveCandle(Vector2.down * 100));
        currCandle = candles[0];
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

        if (currCandle.gameObject.transform.position.x < -maxX ||
            currCandle.gameObject.transform.position.x > maxX ||
            currCandle.gameObject.transform.position.y < -maxY ||
            currCandle.gameObject.transform.position.y > maxY)
        {
            currCandle.transform.Translate(-_direction);
        }
    }

    public List<GameObject> GetCandlesPosition()
    {
        return candles;
    }

}
