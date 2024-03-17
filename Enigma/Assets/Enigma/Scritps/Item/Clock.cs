using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : InteractableItem
{
    [SerializeField] GameEvent onClockOpen;
    public override void Use()
    {
        onClockOpen.Event.Invoke();
    }
}
