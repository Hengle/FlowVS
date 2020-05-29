using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class TextureFiledView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Texture Filed", layoutStyle);
        info.name = EditorGUILayout.TextField("Texture Name", info.name);
        info.animationCurve = EditorGUILayout.CurveField("Filed Curve", info.animationCurve);
        info.floatNumber = EditorGUILayout.FloatField("Time", info.floatNumber);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Texture Filed", layoutStyle);
    }
}

