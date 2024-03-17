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
    GameObject inventory;

    private void Awake()
    {
        inventory = transform.parent.GetChild(0).gameObject;
        clockPuzzleResolution = GetComponent<ClockPuzzleResolution>();
        panel = transform.GetChild(0).gameObject;
        onClockOpen.Event.AddListener(ShowClock);
        closeButton.onClick.AddListener(HideClock);
        panel.SetActive(false);
    }

    private void HideClock()
    {
        panel.SetActive(false);
        inventory.SetActive(true);
    }

    private void ShowClock()
    {
        if (clockPuzzleResolution.GetPuzzleSolvedCheck()) return;

        panel.SetActive(true);
        inventory.SetActive(false);
    }
}
