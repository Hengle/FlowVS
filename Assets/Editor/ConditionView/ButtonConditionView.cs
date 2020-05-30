using FLOW;
using FLOW.Editor.View;
using UnityEditor;
using UnityEngine;

public class ButtonConditionView : ConditionView
{
    public override void DisplayInspector(FinishInfo info)
    {
        GUILayout.Label("Button", inspectorLayoutStyle);
        info.subTextTemplate = EditorGUILayout.ObjectField("Text Template", info.subTextTemplate, typeof(TextTemplate), false) as TextTemplate;
        info.subString = EditorGUILayout.TextField("Button Context", info.subString);
        info.subPosition = EditorGUILayout.Vector3Field("Position", info.subPosition);
        info.subRotation = EditorGUILayout.Vector2Field("Size", info.subRotation);
        info.subSprite = EditorGUILayout.ObjectField("Texture", info.subSprite, typeof(Sprite), false) as Sprite;
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Button", nodeLayoutStyle, GUILayout.Width(200));
    }
}
