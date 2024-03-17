using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockController : MonoBehaviour
{
    [SerializeField] GameEvent onClockOpen;
    [SerializeField] Button closeButton;
    GameObject panel;
    ClockPuzzleResolution clockPuzzleResolution;

    private void Awake()
    {
        clockPuzzleResolution = GetComponent<ClockPuzzleResolution>();
        panel = transform.GetChild(0).gameObject;
        onClockOpen.Event.AddListener(ShowClock);
        closeButton.onClick.AddListener(HideClock);
        panel.SetActive(false);
    }

    private void HideClock()
    {
        panel.SetActive(false);
    }

    private void ShowClock()
    {
        if (clockPuzzleResolution.GetPuzzleSolvedCheck()) return;

        panel.SetActive(true);
    }
}
