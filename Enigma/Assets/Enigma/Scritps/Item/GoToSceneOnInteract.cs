using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSceneOnInteract : InteractableItem
{
    [SerializeField] string sceneName;
    public override void Use()
    {
        SceneController.Instance.LoadScene(sceneName);
    }
}
