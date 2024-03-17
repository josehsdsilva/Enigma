using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : PickableItem
{
    [SerializeField] GameEvent onBookOpen;

    public override void Use()
    {
        //Debug.Log("Book -> Use");
        onBookOpen.Event.Invoke();
    }
}
