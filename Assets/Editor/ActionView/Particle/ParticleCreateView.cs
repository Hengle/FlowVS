using FLOW.Editor.View;
using FLOW;
using UnityEngine;
using UnityEditor;

public class ParticleCreateView : ActionView
{
    public override void DisplayInspectorView(ActionInfo info)
    {
        EditorGUILayout.LabelField("Particle Create", layoutStyle);
        info.obj = EditorGUILayout.ObjectField("Particle", info.obj, typeof(GameObject), false) as GameObject;
        if (!info.obj)
            return;
        var component = info.obj.GetComponentInChildren<ParticleSystem>();
        if (!component)
            info.obj = null;
        info.position = EditorGUILayout.Vector3Field("Position", info.position);
    }

    public override void DisplayNodeView()
    {
        GUILayout.Label("Particle Create", layoutStyle);
    }
}

