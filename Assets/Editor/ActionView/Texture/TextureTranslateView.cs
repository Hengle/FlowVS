using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class TextureTranslateView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Texture Translate", layoutStyle);
        info.name = EditorGUILayout.TextField("Texture Name", info.name);
        info.position = EditorGUILayout.Vector3Field("Destination Position", info.position);
        info.animationCurve = EditorGUILayout.CurveField("Move Curve", info.animationCurve);
        info.floatNumber = EditorGUILayout.FloatField("Time", info.floatNumber);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Texture Translate", layoutStyle);
    }
}

