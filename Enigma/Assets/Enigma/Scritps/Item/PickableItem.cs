using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickableItem : MonoBehaviour
{
    [SerializeField] ItemType itemType;
    [SerializeField] Sprite image;
    bool picked = false;

    public ItemType GetItemType()
    {
        return itemType;
    }

    public Sprite GetImage()
    {
        return image;
    }

    public bool AlreadyPicked()
    {
        return picked;
    }

    public void SetPicked()
    {
        picked = true;
    }

    public virtual void Use()
    {
        Debug.Log("PickableItem -> Use");
    }
}

public enum ItemType
{
    None,
    Book,
    Key1,
    Key2
}
