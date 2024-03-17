using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : InteractableItem
{
    public override void Use()
    {
        SceneController.Instance.InteractWithBow();
    }
}
