using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class TextureBlinkView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Texture Blink", layoutStyle);
        info.name = EditorGUILayout.TextField("Texture Name", info.name);
        info.floatNumber = EditorGUILayout.FloatField("Frame Time", info.floatNumber);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Texture Blink", layoutStyle);
    }
}

