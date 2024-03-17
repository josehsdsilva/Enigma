using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleManager : MonoBehaviour
{
    GameObject bowCandle;
    GameObject diaryCandle;

    private void Start()
    {
        bowCandle = transform.GetChild(1).GetChild(0).gameObject;
        diaryCandle = transform.GetChild(2).GetChild(0).gameObject;
        UpdateCandles();
    }

    public void UpdateCandles()
    {
        bowCandle.SetActive(SceneController.Instance.visited.Count >= 1);
        diaryCandle.SetActive(SceneController.Instance.visited.Count >= 2);
    }
}
