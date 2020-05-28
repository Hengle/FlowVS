using UnityEngine;

namespace FLOW.Editor.View
{
    public abstract class ConditionView
    {
        protected GUIStyle nodeLayoutStyle = new GUIStyle();
        protected GUIStyle inspectorLayoutStyle = new GUIStyle();

        protected ConditionView()
        {
            Color conditionColor = new Color(0.4f, 0.4f, 1f);
            nodeLayoutStyle.alignment = TextAnchor.MiddleCenter;
            nodeLayoutStyle.normal.textColor = conditionColor;
            inspectorLayoutStyle.alignment = TextAnchor.MiddleLeft;
            inspectorLayoutStyle.normal.textColor = conditionColor;
        }

        public abstract void DisplayInspector(FinishInfo info);
        public abstract void DisplayNodeView();
    }
}
