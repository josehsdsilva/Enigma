using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : InteractableItem
{
    public override void Use()
    {
        SceneController.Instance.InteractWithBear();
    }
}
