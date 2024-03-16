using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    [SerializeField] GameEvent onBookOpen;
    [SerializeField] Button closeButton;

    private void Start()
    {
        onBookOpen.Event.AddListener(OpenBook);
        closeButton.onClick.AddListener(CloseBook);
    }

    private void CloseBook()
    {
        gameObject.SetActive(true);
    }

    private void OpenBook()
    {
        gameObject.SetActive(false);
    }
}
