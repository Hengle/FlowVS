using FLOW;
using FLOW.Editor.View;
using UnityEngine;

public class FinishActionConditionView : ConditionView
{
    public override void DisplayInspector(FinishInfo info)
    {
        GUILayout.Label("Finish Action", inspectorLayoutStyle);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label(" Finish Action", nodeLayoutStyle, GUILayout.Width(200));
    }
}
