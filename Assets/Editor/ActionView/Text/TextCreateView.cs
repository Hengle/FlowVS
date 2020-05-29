using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class TextCreateView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Text Create", layoutStyle);
        info.textTemplate = (TextTemplate)EditorGUILayout.ObjectField("Text Template", info.textTemplate, typeof(TextTemplate), false);
        info.position = EditorGUILayout.Vector3Field("Context Position", info.position);
        info.context = EditorGUILayout.TextField("Context", info.context);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Text Create", layoutStyle);
    }
}

