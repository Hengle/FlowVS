using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class SceneFadeOutView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Scene FadeOut", layoutStyle);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Scene FadeOut", layoutStyle);
    }
}

