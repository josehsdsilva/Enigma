using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandleMovement : MonoBehaviour
{
    Camera cam;
    [SerializeField] Button rightArrow, leftArrow, upArrow, downArrow, resetButton;
    [SerializeField] List<RectTransform> candles;
    RectTransform currCandle;
    List<Vector2> startPositions;

    int minX = 100, minY = 100, maxX = 1800, maxY = 800;

    private void Start()
    {
        cam = Camera.main;
        rightArrow.onClick.AddListener(() => MoveCandle(Vector2.right * 100));
        leftArrow.onClick.AddListener(() => MoveCandle(Vector2.left * 100));
        upArrow.onClick.AddListener(() => MoveCandle(Vector2.up * 100));
        downArrow.onClick.AddListener(() => MoveCandle(Vector2.down * 100));
        resetButton.onClick.AddListener(() => ResetCandlePositions());
        currCandle = candles[0];
        SaveStartPosition();
    }

    public void SetCurrentCandle(Candle candle)
    {
        currCandle = candles[(int)candle];
    }

    void SaveStartPosition()
    {
        startPositions = new List<Vector2>();
        for (int i = 0; i < candles.Count; i++)
        {
            startPositions.Add(candles[i].anchoredPosition);
        }
    }

    void ResetCandlePositions()
    {
        for (int i = 0; i < candles.Count; i++)
        {
            candles[i].anchoredPosition = startPositions[i];
        }
    }


    private void MoveCandle(Vector2 _direction)
    {
        if(ValidMovement(_direction))
        {
            currCandle.anchoredPosition += _direction;
        }
    }

    bool ValidMovement(Vector2 _direction)
    {
        bool insideBoundaries = currCandle.anchoredPosition.x + _direction.x < maxX && 
            currCandle.anchoredPosition.x + _direction.x > minX && 
            currCandle.anchoredPosition.y + _direction.y > minY && 
            currCandle.anchoredPosition.y + _direction.y < maxY;

        if (!insideBoundaries)
        {
            Debug.Log("not inside boundaries");
            return false;
        }

        foreach (RectTransform candle in candles)
        {
            if (candle != currCandle)
            {
                if (candle.anchoredPosition == (currCandle.anchoredPosition + _direction))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public List<RectTransform> GetCandlesPosition()
    {
        return candles;
    }
}

public enum Candle
{
    I,
    P,
    O,
    S
}
