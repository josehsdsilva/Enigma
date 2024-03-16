using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    [SerializeField] GameEvent onBookOpen;
    [SerializeField] Button closeButton;
    GameObject panel;

    private void Start()
    {
        onBookOpen.Event.AddListener(OpenBook);
        closeButton.onClick.AddListener(CloseBook);
        panel = transform.GetChild(0).gameObject;
    }

    private void CloseBook()
    {
        //Debug.Log("CloseBook");
        panel.SetActive(false);
    }

    private void OpenBook()
    {
        //Debug.Log("OpenBook");
        panel.SetActive(true);
    }
}
