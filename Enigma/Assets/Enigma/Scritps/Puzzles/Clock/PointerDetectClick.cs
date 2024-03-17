using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerDetectClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] ClockMovement clockMovement;
    [SerializeField] bool isBigPointer;

    public void OnPointerClick(PointerEventData eventData)
    {
        clockMovement.SetPointerClicked(isBigPointer);
    }

}
