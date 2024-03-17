using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    [SerializeField] GameEvent onBookOpen;
    [SerializeField] Button closeButton;
    [SerializeField] Button openButton;
    [SerializeField] GameObject cover;
    [SerializeField] GameObject openBook;
    GameObject panel;

    private void Start()
    {
        onBookOpen.Event.AddListener(ShowBook);
        closeButton.onClick.AddListener(CloseBook);
        openButton.onClick.AddListener(OpenBook);
        panel = transform.GetChild(0).gameObject;
        panel.SetActive(false);
    }

    private void OpenBook()
    {
        cover.SetActive(false);
        openBook.SetActive(true);
        closeButton.gameObject.SetActive(true);
        openButton.gameObject.SetActive(false);
    }

    private void CloseBook()
    {
        //Debug.Log("CloseBook");
        panel.SetActive(false);
    }

    private void ShowBook()
    {
        //Debug.Log("OpenBook");
        panel.SetActive(true);
        cover.SetActive(true);
        openBook.SetActive(false);
        closeButton.gameObject.SetActive(false);
        openButton.gameObject.SetActive(true);
    }
}
