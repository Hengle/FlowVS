using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class TexturePropertiesView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Texture Properties", layoutStyle);
        info.name = EditorGUILayout.TextField("Texture Name", info.name);
        info.position = EditorGUILayout.Vector3Field("Position", info.position);
        info.rotation = EditorGUILayout.Vector3Field("Rotation", info.rotation);
        info.size = EditorGUILayout.Vector2Field("Size", info.size);
        info.floatNumber = EditorGUILayout.FloatField("Scale", info.floatNumber);
        info.boolean = EditorGUILayout.Toggle("Active", info.boolean);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Texture Properties", layoutStyle);
    }
}

