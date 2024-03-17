using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUseZone : MonoBehaviour
{
    [SerializeField] ItemType zoneType;
    [SerializeField] GameEvent_ItemType onZoneEnter;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(nameof(gameObject) + " -> OnTriggerEnter2D");
        if (collision.gameObject.CompareTag("Player"))
        {
            onZoneEnter.Event.Invoke(zoneType);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log(nameof(gameObject) + " -> OnTriggerEnter2D");
        if (collision.gameObject.CompareTag("Player"))
        {
            onZoneEnter.Event.Invoke(ItemType.None);
        }
    }
}
