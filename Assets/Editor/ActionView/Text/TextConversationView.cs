using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class TextConversationView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Text Conversation", layoutStyle);
        info.conversationTemplate = (ConversationTemplate)EditorGUILayout.ObjectField("Conversation Template", info.conversationTemplate, typeof(ConversationTemplate), false);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Text Conversation", layoutStyle);
    }
}

