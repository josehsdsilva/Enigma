using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameEvent_ItemType))]
public class GameEvent_ItemTypeEditor : Editor
{
    private ItemType selectedItemType;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // Cast the target to the GameEvent type
        GameEvent_ItemType gameEvent = (GameEvent_ItemType)target;

        // Display enum dropdown for selecting item type
        selectedItemType = (ItemType)EditorGUILayout.EnumPopup("Item Type", selectedItemType);

        // Create a button to trigger the event with the selected item type
        if (GUILayout.Button("Trigger Event"))
        {
            // Invoke the Response with the selected item type as a parameter
            gameEvent.Event.Invoke(selectedItemType);
        }
    }
}
