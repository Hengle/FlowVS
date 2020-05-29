using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class SceneAdditiveView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Scene Additive", layoutStyle);
        info.name = EditorGUILayout.TextField("Additive Scene Name", info.name);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Scene Additive", layoutStyle);
    }
}

