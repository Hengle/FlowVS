using UnityEngine;

namespace FLOW.Editor.View
{
    public abstract class ActionView
    {
        protected GUIStyle layoutStyle = new GUIStyle();

        protected ActionView()
        {
            layoutStyle.alignment = TextAnchor.MiddleLeft;
            layoutStyle.normal.textColor = new Color(0.7f, 0.3f, 0.3f);
        }

        public abstract void DisplayInspectorView(ActionInfo info);
        public abstract void DisplayNodeView();
    }
}
