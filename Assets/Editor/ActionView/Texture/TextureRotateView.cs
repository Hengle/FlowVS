using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class TextureRotateView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Texture Rotate", layoutStyle);
        info.name = EditorGUILayout.TextField("Texture Name", info.name);
        info.rotation = EditorGUILayout.Vector3Field("Destination Position", info.rotation);
        info.animationCurve = EditorGUILayout.CurveField("Rotation Curve", info.animationCurve);
        info.floatNumber = EditorGUILayout.FloatField("Time", info.floatNumber);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Texture Rotate", layoutStyle);
    }
}

