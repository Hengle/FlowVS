using FLOW;
using FLOW.Editor.View;
using UnityEditor;
using UnityEngine;

public class CountdownConditionView :  ConditionView
{
    public override void DisplayInspector(FinishInfo info)
    {
        GUILayout.Label("Countdown", inspectorLayoutStyle);
        info.subFloat = EditorGUILayout.FloatField("Time", info.subFloat);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Countdown", nodeLayoutStyle, GUILayout.Width(200));
    }
}
