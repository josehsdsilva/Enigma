using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] GameEvent_GameObject onItemPicked;
    GameObject interactableObject;
    Item itemScript;
    bool canMove;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState newState)
    {
        canMove = newState == GameState.Play;
    }

    public void SetCloseToObject(GameObject go)
    {
        if (go && go.GetComponent<Item>() && go.GetComponent<Item>().AlreadyPicked()) return;

        interactableObject = go;
        if(interactableObject)
        {
            itemScript = interactableObject.GetComponent<Item>();
        }
    }

    private void Update()
    {
        if (!canMove) return;

        if (Input.GetKey(KeyCode.E) && interactableObject)
        {
            if(itemScript)
            {
                onItemPicked.Event.Invoke(interactableObject);
                SetCloseToObject(null);
            }
        }
    }
}
