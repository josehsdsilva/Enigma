using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Item
{
    [SerializeField] GameEvent onBookOpen;

    public override void Use()
    {
        onBookOpen.Event.Invoke();
    }
}
