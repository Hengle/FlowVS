using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class SceneTransitionView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Scene Transition", layoutStyle);
        info.name = EditorGUILayout.TextField("Load Scene Name", info.name);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Scene Transition", layoutStyle);
    }
}

