using FLOW;
using FLOW.Editor.View;
using UnityEngine;

public class AnykeyConditionView : ConditionView
{
    public override void DisplayInspector(FinishInfo info)
    {
        GUILayout.Label("Anykey", inspectorLayoutStyle);
    }
    public override void DisplayNodeView()
    {
        GUILayout.Label("Anykey", nodeLayoutStyle,GUILayout.Width(200));
    }
}
