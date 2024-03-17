using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : InteractableItem
{
    [SerializeField] GameEvent onAltarOpen;
    public override void Use()
    {
        onAltarOpen.Event.Invoke();
    }
}
