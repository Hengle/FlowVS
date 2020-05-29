using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class CharacterRotateView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Character Rotate", layoutStyle);
        info.objectTemplate = EditorGUILayout.ObjectField("Character", info.objectTemplate, typeof(ObjectTemplate), false) as ObjectTemplate;
        info.rotation = EditorGUILayout.Vector3Field("Destination Position", info.rotation);
        info.animationCurve = EditorGUILayout.CurveField("Move Curve", info.animationCurve);
        info.floatNumber = EditorGUILayout.FloatField("Time", info.floatNumber);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Character Rotate", layoutStyle);
    }
}

