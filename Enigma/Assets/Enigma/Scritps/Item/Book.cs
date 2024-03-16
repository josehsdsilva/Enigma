using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Item
{
    [SerializeField] GameEvent onBookOpen;

    public override void Use()
    {
        //Debug.Log("Book -> Use");
        onBookOpen.Event.Invoke();
    }
}
