using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public virtual void Use()
    {
        Debug.Log("InteractableItem -> Use");
    }
}
