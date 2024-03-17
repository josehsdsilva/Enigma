using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] GameEvent_GameObject onItemPicked;
    GameObject interactableObject;
    PickableItem pickableItem;
    InteractableItem interactableItem;
    bool canMove = true;

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
        //canMove = newState == GameState.Play;
    }

    public void SetCloseToObject(GameObject go)
    {
        if (go && go.GetComponent<PickableItem>() && go.GetComponent<PickableItem>().AlreadyPicked()) return;

        interactableObject = go;
        if(interactableObject == null)
        {
            pickableItem = null;
        }
        else if(interactableObject && interactableObject.GetComponent<PickableItem>())
        {
            pickableItem = interactableObject.GetComponent<PickableItem>();
        }
        else if (interactableObject && interactableObject.GetComponent<InteractableItem>())
        {
            interactableItem = interactableObject.GetComponent<InteractableItem>();
        }
    }

    private void Update()
    {
        if (!canMove) return;

        if (Input.GetKey(KeyCode.E) && interactableObject && (interactableItem || pickableItem) )
        {
            if(pickableItem)
            {
                onItemPicked.Event.Invoke(interactableObject);
                SetCloseToObject(null);
            }
            else if(interactableItem != null)
            {
                interactableItem.Use();
            }
        }
    }
}
