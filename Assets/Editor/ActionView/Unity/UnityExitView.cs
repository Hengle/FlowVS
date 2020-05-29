using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class UnityExitView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Unity Exit", layoutStyle);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Unity Exit", layoutStyle);
    }
}

