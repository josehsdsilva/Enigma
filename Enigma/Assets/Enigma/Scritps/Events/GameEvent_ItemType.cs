using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameEvent_ItemType", menuName = "Events/New GameEvent_ItemType", order = 1)]
public class GameEvent_ItemType : ScriptableObject
{
    [HideInInspector] public UnityEvent<ItemType> Event;
}
