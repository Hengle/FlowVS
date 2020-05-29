using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class CameraRotateView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Camera Rotate", layoutStyle);
        info.rotation = EditorGUILayout.Vector3Field("Rotation", info.rotation);
        info.animationCurve = EditorGUILayout.CurveField("Move Curve", info.animationCurve);
        info.floatNumber = EditorGUILayout.FloatField("Time", info.floatNumber);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Camera Rotate", layoutStyle);
    }
}

