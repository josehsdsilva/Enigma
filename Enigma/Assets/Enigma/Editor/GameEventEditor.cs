using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    private ItemType selectedItemType;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // Cast the target to the GameEvent type
        GameEvent gameEvent = (GameEvent)target;

        // Display enum dropdown for selecting item type
        selectedItemType = (ItemType)EditorGUILayout.EnumPopup("Item Type", selectedItemType);

        // Create a button to trigger the event with the selected item type
        if (GUILayout.Button("Trigger Event"))
        {
            // Invoke the Response with the selected item type as a parameter
            gameEvent.Response.Invoke(selectedItemType);
        }
    }
}
