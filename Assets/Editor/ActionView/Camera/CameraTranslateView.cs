using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class CameraTranslateView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Camera Translate", layoutStyle);
        info.position = EditorGUILayout.Vector3Field("Destination Position", info.position);
        info.animationCurve = EditorGUILayout.CurveField("Move Curve", info.animationCurve);
        info.floatNumber = EditorGUILayout.FloatField("Time", info.floatNumber);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Camera Tanslate", layoutStyle);
    }
}

