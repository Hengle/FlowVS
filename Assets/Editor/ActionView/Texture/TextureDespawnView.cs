using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class TextureDespawnView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Texture Despawn", layoutStyle);
        info.name = EditorGUILayout.TextField("Texture Name", info.name);    
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Texture Despawn", layoutStyle);
    }
}

