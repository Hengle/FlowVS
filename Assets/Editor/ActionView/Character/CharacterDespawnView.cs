using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class CharacterDespawnView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Character Despawn", layoutStyle);
        info.objectTemplate = EditorGUILayout.ObjectField("Character", info.objectTemplate, typeof(ObjectTemplate), false) as ObjectTemplate;
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Character Despawn", layoutStyle);
    }
}

