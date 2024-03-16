using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandlePuzleResolution : MonoBehaviour
{
    [SerializeField] Transform candleIPosition, candlePPosition, candleOPosition, candleSPosition;
    CandleMovement candleMovementScript;

    bool ispuzzleSolved = false;

    private void Start()
    {
        candleMovementScript = GetComponent<CandleMovement>();
    }

    private void Update()
    {
        PuzzleSolvedCheked();
    }

    private void PuzzleSolvedCheked()
    {
        Debug.Log("Solving");
        List<GameObject> positions = candleMovementScript.GetCandlesPosition();

        if (positions[0].transform.position == candleIPosition.position &&
           positions[1].transform.position == candlePPosition.position &&
           positions[2].transform.position == candleOPosition.position &&
           positions[3].transform.position == candleSPosition.position)
        {
            ispuzzleSolved = true;
            Debug.Log("PuzzleSolved");
        }
    }

    public bool GetPuzzleSolvedCheck()
    {
        return ispuzzleSolved;
    }
}
