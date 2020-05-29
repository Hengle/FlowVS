using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class TextureCreateView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Texture Create", layoutStyle);
        info.name = EditorGUILayout.TextField("Texture Name", info.name);
        info.sprite = EditorGUILayout.ObjectField("Texture", info.sprite, typeof(Sprite), false) as Sprite;
        info.position = EditorGUILayout.Vector3Field("Position", info.position);
        info.rotation = EditorGUILayout.Vector3Field("Rotation", info.rotation);
        info.size = EditorGUILayout.Vector2Field("Size", info.size);
        info.floatNumber = EditorGUILayout.FloatField("Scale", info.floatNumber);
        info.boolean = EditorGUILayout.Toggle("Active", info.boolean);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Texture Create", layoutStyle);
    }
}

