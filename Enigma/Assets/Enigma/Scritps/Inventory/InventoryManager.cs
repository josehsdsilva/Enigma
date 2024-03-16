using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameEvent_ItemType onInsideZone;
    [SerializeField] GameEvent_GameObject onItemPicked;
    List<InventoryItemSlot> items;
    ItemType interactionZone;

    [Header("Testing")]
    [SerializeField] GameObject bookPrefab;
    [SerializeField] GameObject key1;
    [SerializeField] GameObject key2;

    private void Awake()
    {
        items = transform.GetComponentsInChildren<InventoryItemSlot>().ToList();
        onInsideZone.Event.AddListener(UpdateInteractionZone);
        onItemPicked.Event.AddListener(ItemPicked);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseItem(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseItem(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseItem(3);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddItem(key1);
        }

    }

    void UpdateInteractionZone(ItemType itemType)
    {
        interactionZone = itemType;
    }

    void ItemPicked(GameObject gameObject)
    {
        gameObject.SetActive(false);
        AddItem(gameObject);
    }

    public void AddItem(GameObject go)
    {
        Debug.Log(nameof(gameObject) + " -> AddItem");
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].IsEmpty())
            {
                items[i].AddItem(go);
                return;
            }
        }

        // Inventory is full
    }

    public void UseItem(int id)
    {
        if(items[id].GetItemType() == ItemType.Book || items[id].GetItemType() != ItemType.None && items[id].GetItemType() == interactionZone)
        {
            Debug.Log(nameof(gameObject) + " -> UseItem");
            items[id].UseItem();
        }
    }
}
