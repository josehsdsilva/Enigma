using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(nameof(gameObject) + " -> OnTriggerEnter2D");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerInteraction>().SetCloseToObject(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log(nameof(gameObject) + " -> OnTriggerEnter2D");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerInteraction>().SetCloseToObject(null);
        }
    }
}
