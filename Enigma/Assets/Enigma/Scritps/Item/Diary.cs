using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : InteractableItem
{
    public override void Use()
    {
        SceneController.Instance.InteractWithDiary();
    }
}
