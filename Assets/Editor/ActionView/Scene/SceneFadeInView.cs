using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class SceneFadeInView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Scene FadeIn", layoutStyle);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Scene FadeIn", layoutStyle);
    }
}

