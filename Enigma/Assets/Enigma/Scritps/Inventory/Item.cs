using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] ItemType itemType;
    [SerializeField] Sprite image;

    public ItemType GetItemType()
    {
        return itemType;
    }

    public Sprite GetImage()
    {
        return image;
    }
}

public enum ItemType
{
    None,
    Book,
    Key1,
    Key2
}
