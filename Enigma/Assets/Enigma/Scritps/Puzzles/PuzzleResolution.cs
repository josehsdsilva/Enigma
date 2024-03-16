using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleResolution : MonoBehaviour
{
    bool isPuzzleSolved = false;
    float smallPointerAngle, bigPointerAngle;

    private void Update()
    {
        PuzzleSolvedCheck();
    }

    private void PuzzleSolvedCheck()
    {
        if(smallPointerAngle == 90 && bigPointerAngle == 180 && !isPuzzleSolved)
        {
            Debug.Log("PuzzleSolved");
            isPuzzleSolved = true;
        }
    }

    public void GetAnglesForPointers(float _smallPointerAngle, float _bigPointerAngle)
    {
        smallPointerAngle = _smallPointerAngle;
        bigPointerAngle = _bigPointerAngle;
    }

}
