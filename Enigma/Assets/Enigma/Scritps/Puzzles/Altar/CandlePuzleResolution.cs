using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandlePuzleResolution : MonoBehaviour
{
    [SerializeField] GameEvent onAltarPuzzleCompleted;
    [SerializeField] List<RectTransform> candlePositions;
    CandleMovement candleMovementScript;

    List<Image> onCandleImages;

    bool ispuzzleSolved = false;
    List<RectTransform> positions;
    int solvedCounter = 0;

    private void Start()
    {
        candleMovementScript = GetComponent<CandleMovement>();
        positions = candleMovementScript.GetCandlesPosition();
        onCandleImages = new();
        for (int i = 0; i < candlePositions.Count; i++)
        {
            onCandleImages.Add(candlePositions[i].GetChild(0).GetComponent<Image>());
        }
    }

    private void Update()
    {
        if (ispuzzleSolved) return;

        PuzzleSolvedCheked();
    }

    private void PuzzleSolvedCheked()
    {
        Debug.Log("Solving");


        //positions = candleMovementScript.GetCandlesPosition();

        solvedCounter = 0;

        for (int i = 0; i < candlePositions.Count; i++)
        {
            onCandleImages[i].enabled = positions[i].anchoredPosition == candlePositions[i].anchoredPosition;
            if (positions[i].anchoredPosition == candlePositions[i].anchoredPosition)
            {
                solvedCounter++;
            }
        }

        if (solvedCounter >= 4)
        {
            ispuzzleSolved = true;
            onAltarPuzzleCompleted.Event.Invoke();
        }
    }

    public bool GetPuzzleSolvedCheck()
    {
        return ispuzzleSolved;
    }
}
