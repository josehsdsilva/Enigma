using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzleResolution : MonoBehaviour
{
    [SerializeField] GameEvent onClockPuzzleCompleted;
    [SerializeField] GameObject openDoorClock;
    [SerializeField] GameObject key;

    bool isPuzzleSolved = false;
    float smallPointerAngle, bigPointerAngle;

    private void Start()
    {
        openDoorClock.SetActive(false);
        key.SetActive(false);
    }

    private void Update()
    {
        PuzzleSolvedCheck();
    }

    private void PuzzleSolvedCheck()
    {
        if(smallPointerAngle == 180 && bigPointerAngle == 90 && !isPuzzleSolved)
        {
            openDoorClock.SetActive(true);
            key.SetActive(true);
            onClockPuzzleCompleted.Event.Invoke();
            isPuzzleSolved = true;
        }
    }

    public void SetAnglesForPointers(float _smallPointerAngle, float _bigPointerAngle)
    {
        smallPointerAngle = _smallPointerAngle;
        bigPointerAngle = _bigPointerAngle;
    }

    public bool GetPuzzleSolvedCheck()
    {
        return isPuzzleSolved;
    }

}
