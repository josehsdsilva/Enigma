using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockMovement : MonoBehaviour
{
    GameObject currClockPointer;
    [SerializeField] Camera cam;
    [SerializeField] GameObject bigClockPointer;
    [SerializeField] GameObject smallClockPointer;
    [SerializeField] Button moveClockPointerRightBtn, moveClockPointerLeftBtn;
    ClockPuzzleResolution puzzleResolution;

    private void Start()
    {
        currClockPointer = bigClockPointer;
        puzzleResolution = GetComponent<ClockPuzzleResolution>();

        moveClockPointerLeftBtn.onClick.AddListener(() => MoveClockPointers(30));
        moveClockPointerRightBtn.onClick.AddListener(() => MoveClockPointers(-30));
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

            if (raycast2D.collider && raycast2D.collider.gameObject.CompareTag("BigClockPointer"))
            {
                currClockPointer = bigClockPointer;
            }
            else if (raycast2D.collider && raycast2D.collider.gameObject.CompareTag("SmallClockPointer")) 
            {
                currClockPointer = smallClockPointer;
            } 
        }
    }

    private void MoveClockPointers(int _degrees)
    {
        currClockPointer.transform.Rotate(new Vector3(0, 0, _degrees), Space.World);
        float smallPointerAngle = smallClockPointer.transform.rotation.eulerAngles.z;
        float bigPointerAngle = bigClockPointer.transform.rotation.eulerAngles.z;
        puzzleResolution.SetAnglesForPointers(smallPointerAngle, bigPointerAngle);
    }
}
