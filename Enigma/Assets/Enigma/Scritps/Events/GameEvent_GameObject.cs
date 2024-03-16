using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameEvent_GameObject", menuName = "Events/New GameEvent_GameObject", order = 2)]
public class GameEvent_GameObject : ScriptableObject
{
    [HideInInspector] public UnityEvent<GameObject> Event;
}
