using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAltarPuzzleCompletedListener : MonoBehaviour
{
    [SerializeField] GameEvent onAltarPuzzleCompleted;
    GameObject wrongPlacedCandles;
    GameObject correctPlacedCandles;
    BoxCollider2D boxCollider;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        onAltarPuzzleCompleted.Event.AddListener(OpenDoorAndInstantiateKey);
        wrongPlacedCandles = transform.GetChild(0).gameObject;
        correctPlacedCandles = transform.GetChild(1).gameObject;
        correctPlacedCandles.SetActive(false);
        wrongPlacedCandles.SetActive(true);
    }

    private void OpenDoorAndInstantiateKey()
    {
        boxCollider.enabled = false;
        correctPlacedCandles.SetActive(true);
        wrongPlacedCandles.SetActive(false);
    }
}
