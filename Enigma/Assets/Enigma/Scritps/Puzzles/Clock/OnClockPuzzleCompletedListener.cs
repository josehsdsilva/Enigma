using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClockPuzzleCompletedListener : MonoBehaviour
{
    [SerializeField] GameEvent onClockPuzzleCompleted;
    [SerializeField] GameObject keyPrefab;
    GameObject clockWithOpenDoor;
    Transform keyPosition;
    BoxCollider2D boxCollider;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        clockWithOpenDoor = transform.GetChild(3).gameObject;
        keyPosition = transform.GetChild(4);
        onClockPuzzleCompleted.Event.AddListener(OpenDoorAndInstantiateKey);
        clockWithOpenDoor.SetActive(false);
    }

    private void OpenDoorAndInstantiateKey()
    {
        boxCollider.enabled = false;
        clockWithOpenDoor.SetActive(true);
        Instantiate(keyPrefab, keyPosition.position, Quaternion.identity);
    }
}
