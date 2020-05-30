using FLOW;
using FLOW.Editor.View;
using UnityEngine;

public class NoneConditionView : ConditionView
{
    public override void DisplayInspector(FinishInfo info)
    {
        GUILayout.Label("None", inspectorLayoutStyle);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("None", nodeLayoutStyle, GUILayout.Width(200));
    }
}
