using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CharacterAnimationView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Character Animation", layoutStyle);
        info.objectTemplate = EditorGUILayout.ObjectField("Character", info.objectTemplate, typeof(ObjectTemplate), false) as ObjectTemplate;

        if (info.objectTemplate == null)
            return;
        if (info.objectTemplate.obj == null)
            return;

        if (info.objectTemplate.obj.GetComponentInChildren<Animator>() == null)
        {
            EditorGUILayout.LabelField("사용 가능한 Animation이 없습니다.");
            return;
        }

        var controller = info.objectTemplate.obj.GetComponentInChildren<Animator>()
            .runtimeAnimatorController as UnityEditor.Animations.AnimatorController;
        List<string> animationList = new List<string>();
        foreach (var state in controller.layers[0].stateMachine.states)
            animationList.Add(state.state.name);
        info.intNumber = EditorGUILayout.Popup("Animation List : ", info.intNumber, animationList.ToArray());
        info.name = animationList[info.intNumber];
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Character Animation", layoutStyle);
    }

    void FindAnimation(GameObject obj)
    {

    }
}

