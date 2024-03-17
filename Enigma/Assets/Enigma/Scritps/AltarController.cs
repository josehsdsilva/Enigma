using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltarController : MonoBehaviour
{
    [SerializeField] GameEvent onAlterOpen;
    [SerializeField] Button closeButton;
    GameObject panel;
    CandlePuzleResolution candlePuzleResolution;
    GameObject inventory;

    private void Awake()
    {
        inventory = transform.parent.GetChild(0).gameObject;
        candlePuzleResolution = GetComponent<CandlePuzleResolution>();
        panel = transform.GetChild(0).gameObject;
        onAlterOpen.Event.AddListener(ShowAltar);
        closeButton.onClick.AddListener(HideAltar);
        panel.SetActive(false);
    }

    private void HideAltar()
    {
        panel.SetActive(false);
        inventory.SetActive(true);
    }

    private void ShowAltar()
    {
        if (candlePuzleResolution.GetPuzzleSolvedCheck()) return;

        panel.SetActive(true);
        inventory.SetActive(false);
    }
}
