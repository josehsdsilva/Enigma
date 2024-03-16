using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameEvent_GameObject", menuName = "Events/New GameEvent", order = 2)]
public class GameEvent : ScriptableObject
{
    [HideInInspector] public UnityEvent Event;
}
