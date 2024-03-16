using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
