using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class CharacterPropertiesView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Character Properties", layoutStyle);
        info.objectTemplate = EditorGUILayout.ObjectField("Character", info.objectTemplate, typeof(ObjectTemplate), false) as ObjectTemplate;
        info.position = EditorGUILayout.Vector3Field("Position", info.position);
        info.rotation = EditorGUILayout.Vector3Field("Rotation", info.rotation);
        info.floatNumber = EditorGUILayout.FloatField("Scale", info.floatNumber);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Character Properties", layoutStyle);
    }
}

