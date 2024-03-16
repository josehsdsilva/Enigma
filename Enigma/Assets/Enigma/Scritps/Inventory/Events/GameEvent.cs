using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Events", order = 1)]
public class GameEvent : ScriptableObject
{
    [HideInInspector] public UnityEvent<ItemType> Response;
}
