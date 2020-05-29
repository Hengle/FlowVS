using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class CameraPropertiesView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Camera Properties", layoutStyle);
        info.position = EditorGUILayout.Vector3Field("Position", info.position);
        info.rotation = EditorGUILayout.Vector3Field("Rotation", info.rotation);
        info.floatNumber = EditorGUILayout.FloatField("Zoom", info.floatNumber);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Camera Properties", layoutStyle);
    }
}

