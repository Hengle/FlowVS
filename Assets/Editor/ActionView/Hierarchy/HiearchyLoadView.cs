using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class HiearchyLoadView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Hiearchy Load", layoutStyle);
        info.flowHierarchy = EditorGUILayout.ObjectField("FlowHierarchy", info.flowHierarchy, typeof(FlowHierarchy), false) as FlowHierarchy;
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Hiearchy Load", layoutStyle);
    }
}

