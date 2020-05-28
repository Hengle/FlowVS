using UnityEngine;
using UnityEditor;

namespace FLOW.Editor
{
    public class EditorGUISplitView
    {
        public enum Direction
        {
            Horizontal,
            Vertical
        }

        Direction splitDirection;
        float splitNormalizedPosition;
        bool resize;
        bool isSizeable;

        public Vector2 scrollPosition;
        Rect availableRect;
        public EditorGUISplitView(Direction splitDirection, float splitNormalizedPosition, bool isSizeable)
        {
            this.splitNormalizedPosition = splitNormalizedPosition;
            this.splitDirection = splitDirection;
            this.isSizeable = isSizeable;
        }

        public void BeginSplitView()
        {
            Rect tempRect;
            if (splitDirection == Direction.Horizontal)
                tempRect = EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            else
                tempRect = EditorGUILayout.BeginVertical(GUILayout.ExpandHeight(true));

            if (tempRect.width > 0.0f)
                availableRect = tempRect;

            if (splitDirection == Direction.Horizontal)
                scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(availableRect.width * splitNormalizedPosition));
            else
                scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(availableRect.height * splitNormalizedPosition));

            if (Event.current.button == 2)
            {
                scrollPosition -= Event.current.delta * 0.5f;
            }
        }

        public void Split()
        {
            GUILayout.EndScrollView();
            if (isSizeable)
                ResizeSplitFirstView();
        }

        public void EndSplitView()
        {
            if (splitDirection == Direction.Horizontal)
                EditorGUILayout.EndHorizontal();
            else
                EditorGUILayout.EndVertical();
        }

        private void ResizeSplitFirstView()
        {
            Rect resizeHandleRect;
            if (splitDirection == Direction.Horizontal)
                resizeHandleRect = new Rect(availableRect.width * splitNormalizedPosition, availableRect.y, 3f, availableRect.height);
            else
                resizeHandleRect = new Rect(availableRect.x, availableRect.height * splitNormalizedPosition, availableRect.width, 3f);

            EditorGUI.DrawRect(resizeHandleRect, Color.black);

            if (splitDirection == Direction.Horizontal)
                EditorGUIUtility.AddCursorRect(resizeHandleRect, MouseCursor.ResizeHorizontal);
            else
                EditorGUIUtility.AddCursorRect(resizeHandleRect, MouseCursor.ResizeVertical);

            if (Event.current.type == EventType.MouseDown && resizeHandleRect.Contains(Event.current.mousePosition))
            {
                resize = true;
            }
            if (resize)
            {
                if (splitDirection == Direction.Horizontal)
                    splitNormalizedPosition = Event.current.mousePosition.x / availableRect.width;
                else
                    splitNormalizedPosition = Event.current.mousePosition.y / availableRect.height;
            }
            if (Event.current.type == EventType.MouseUp)
                resize = false;
        }
    }
}