using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour
{
    private GameObject itemGO;
    private Item itemScript;
    private Image itemImage;

    private void Start()
    {
        itemImage = transform.GetChild(0).GetComponent<Image>();
    }

    public void AddItem(GameObject go)
    {
        //Debug.Log(nameof(gameObject) + " -> AddItem");
        itemGO = go;
        itemScript = itemGO.GetComponent<Item>();
        itemScript.SetPicked();
        itemImage.sprite = itemScript.GetImage();
        itemImage.enabled = true;
    }

    void RemoveItem()
    {
        itemGO = null;
        itemScript = null;
        itemImage = null;
        itemImage.enabled = false;
    }

    public bool IsEmpty()
    {
        return itemScript == null;
    }

    public ItemType GetItemType()
    {
        if (itemScript == null) return ItemType.None;
        return itemScript.GetItemType();
    }

    public void UseItem()
    {
        Debug.Log(nameof(gameObject) + " -> UseItem");
        itemScript.Use();
        //RemoveItem();
    }
}
