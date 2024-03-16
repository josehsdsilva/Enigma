using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    [SerializeField] GameEvent onKeyUse;
    //[SerializeField] GameEvent_ItemType onKeyUse;
    //[SerializeField] ItemType itemType;

    public override void Use()
    {
        //Debug.Log("Key -> Use");
        onKeyUse.Event.Invoke();
        //onKeyUse.Event.Invoke(itemType);
    }
}
