using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CandleDetectClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] CandleMovement candleMovement;
    [SerializeField] Candle candle;

    public void OnPointerClick(PointerEventData eventData)
    {
        candleMovement.SetCurrentCandle(candle);
    }
}
