using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using FLOW.Player;
using FLOW.Editor.View;
using System.IO;

namespace FLOW.Editor
{
    public abstract class FlowEditor : EditorWindow
    {
        EditorGUISplitView horizontalSplitView = new EditorGUISplitView(EditorGUISplitView.Direction.Horizontal, 0.15f, true);
        EditorGUISplitView horizontalSplitView2 = new EditorGUISplitView(EditorGUISplitView.Direction.Horizontal, 0.78f, false);
        EditorGUISplitView verticalSplitView = new EditorGUISplitView(EditorGUISplitView.Direction.Vertical, 0.98f, false);
        Texture2D arrowTexture;
        Color startNodeColor = new Color(0.6f, 1, 0.5f);
        Color previewNodeColor = new Color(1f, 1f, 0.6f);
        Color selectedNodeColor = new Color(0.1f, 0.3f, 0.4f);
        GUIStyle layoutStyle = new GUIStyle();
        GUIStyle InspectorLogoStyle = new GUIStyle();
        private GUIStyle nodeBackgroundStyle;
        float nodeSectionSize = 5000f;

        const string PATH = "Assets/Resources/FlowHierarchy/";
        protected FlowHierarchy flowHierarchy;
        FlowHierarchy[] loadHierarchy;
        string createHierarchyName;
        string deleteHierarchyName;

        public Dictionary<string, ActionView> actionList = new Dictionary<string, ActionView>();
        public Dictionary<string, ConditionView> conditionList = new Dictionary<string, ConditionView>();
        public List<string> finishCondtionList = new List<string>();

        int selectedNodeIndex = -1;
        string selectedObjectName;
        int mouseOnNodeIndex = 0;
        bool isMouseOnNode = false;
        bool isTransitionMode = false;
        int branchIndex = -1;
        Vector2 mousePos;
        Vector2 clickMousePos;

        abstract protected void AddActionList();
        abstract protected void AddConditionList();
        abstract protected void SetHierarchyPlayer();
        void AddFinishConditionList()
        {
            foreach (var conditionName in conditionList)
                finishCondtionList.Add(conditionName.Key);
        }
        void OnEnable()
        {
            nodeBackgroundStyle = new GUIStyle();
            nodeBackgroundStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/backgroundwithinnershadow.png") as Texture2D;
            nodeBackgroundStyle.border = new RectOffset(12, 12, 12, 12);

            arrowTexture = Resources.Load<Texture2D>("arrow");
            InspectorLogoStyle.alignment = TextAnchor.MiddleCenter;
            InspectorLogoStyle.fontStyle = FontStyle.Bold;
            InspectorLogoStyle.normal.textColor = new Color(0.1f, 0.5f, 0.6f);
            InspectorLogoStyle.fontSize = 20;

            AddActionList();
            AddConditionList();
            AddFinishConditionList();
        }
        void OnGUI()
        {
            //ProjectView
            horizontalSplitView.BeginSplitView();
            DisplayProjectView();
            horizontalSplitView.Split();

            // NodeView
            horizontalSplitView2.BeginSplitView();
            DisplayNodeView();
            horizontalSplitView2.Split();

            // InspectorView
            verticalSplitView.BeginSplitView();
            DisplayActionView();
            DisplayBranchView();
            verticalSplitView.Split();
            verticalSplitView.EndSplitView();
            horizontalSplitView.EndSplitView();
            horizontalSplitView2.EndSplitView();
            Repaint();
        }

        protected virtual void DisplayProjectView()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("New Hierarchy", EditorStyles.boldLabel, GUILayout.Width(120));
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Save", GUILayout.Width(65)))
                SaveFlowHierarchy();
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            createHierarchyName = EditorGUILayout.TextField(createHierarchyName, GUILayout.Width(120));
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Create", GUILayout.Width(65)))
                CreateFlowHierarchy(createHierarchyName);
            GUILayout.EndHorizontal();
            SeparateLayout(5);

            loadHierarchy = Resources.LoadAll<FlowHierarchy>("FlowHierarchy/");
            GUILayout.Label("Hierarchy List", EditorStyles.boldLabel);

            foreach (var hierarchy in loadHierarchy)
            {
                if (GUILayout.Button(hierarchy.name, EditorStyles.toolbarButton))
                {
                    selectedNodeIndex = -1;
                    if (Event.current.button == 0)
                        flowHierarchy = (FlowHierarchy)AssetDatabase.LoadAssetAtPath(PATH + hierarchy.name + ".asset", typeof(FlowHierarchy));
                    else if (Event.current.button == 1)
                    {
                        deleteHierarchyName = hierarchy.name;
                        GenericMenu menu = new GenericMenu();
                        menu.AddItem(new GUIContent("삭제하기"), false, WindowClickCallback, "DeleteHierarchy");
                        menu.ShowAsContext();
                    }
                }
            }

            if (!flowHierarchy)
                return;
            GUILayout.Label("Loaded : " + flowHierarchy.name);
            SeparateLayout(5);

            GUILayout.Label("Hierarchy Player", EditorStyles.boldLabel);
            flowHierarchy.hierarchyPlayer = EditorGUILayout.ObjectField("Player", flowHierarchy.hierarchyPlayer, typeof(GameObject), false) as GameObject;
            if (flowHierarchy.hierarchyPlayer)
            {
                var component = flowHierarchy.hierarchyPlayer.GetComponent<FlowPlayer>();
                if (!component)
                    flowHierarchy.hierarchyPlayer = null;
            }
        }
        protected virtual void DisplayNodeView()
        {
            CreateSection(nodeSectionSize);
            if (!flowHierarchy)
                return;

            CheckNodeViewMouse();
            DrawEdges();
            DrawNodes();
        }
        protected virtual void DisplayActionView()
        {
            if (selectedNodeIndex == -1)
                return;
            if (flowHierarchy.flowNodes[selectedNodeIndex].actions.Count == 0)
                return;

            DrawUILine(Color.gray, 5);
            EditorGUILayout.Separator();
            GUILayout.Label("Actions", InspectorLogoStyle);
            EditorGUILayout.Separator();

            for (int i = 0; i < flowHierarchy.flowNodes[selectedNodeIndex].actions.Count; i++)
            {
                DrawUILine(Color.gray);
                ActionInfo action = flowHierarchy.flowNodes[selectedNodeIndex].actions[i];
                actionList[action.actionName].DisplayInspectorView(action);
                EditorGUILayout.Separator();
                conditionList[finishCondtionList[action.finishConditionIndex]].DisplayInspector(action.finishInfo);
                GUILayout.BeginHorizontal();
                if (i > 0)
                {
                    if (GUILayout.Button("▲", GUILayout.Width(22)))
                    {
                        var temp = flowHierarchy.flowNodes[selectedNodeIndex].actions[i - 1];
                        flowHierarchy.flowNodes[selectedNodeIndex].actions[i - 1] = flowHierarchy.flowNodes[selectedNodeIndex].actions[i];
                        flowHierarchy.flowNodes[selectedNodeIndex].actions[i] = temp;
                    }
                }
                if (i < flowHierarchy.flowNodes[selectedNodeIndex].actions.Count - 1)
                {
                    if (GUILayout.Button("▼", GUILayout.Width(22)))
                    {
                        var temp = flowHierarchy.flowNodes[selectedNodeIndex].actions[i + 1];
                        flowHierarchy.flowNodes[selectedNodeIndex].actions[i + 1] = flowHierarchy.flowNodes[selectedNodeIndex].actions[i];
                        flowHierarchy.flowNodes[selectedNodeIndex].actions[i] = temp;
                    }
                }

                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Delete", GUILayout.Width(50)))
                {
                    ResetNodeSize(flowHierarchy.flowNodes[selectedNodeIndex]);
                    flowHierarchy.flowNodes[selectedNodeIndex].actions.RemoveAt(i);
                }
                GUILayout.EndHorizontal();
            }
        }
        protected virtual void DisplayBranchView()
        {
            if (selectedNodeIndex == -1)
                return;
            if (flowHierarchy.flowNodes[selectedNodeIndex].branches.Count == 0)
                return;

            SeparateLayout(3);
            DrawUILine(Color.gray, 5);
            EditorGUILayout.Separator();
            GUILayout.Label("Branches", InspectorLogoStyle);
            EditorGUILayout.Separator();
            foreach (BranchInfo branch in flowHierarchy.flowNodes[selectedNodeIndex].branches)
            {
                DrawUILine(Color.gray);
                conditionList[branch.branchName].DisplayInspector(branch.finishInfo);
            }
            DrawUILine(Color.gray);
        }

        void SaveFlowHierarchy()
        {
            if (flowHierarchy)
            {
                EditorUtility.SetDirty(flowHierarchy);
                AssetDatabase.SaveAssets();
                Debug.Log("Save 되었습니다.");
            }
        }
        void CreateFlowHierarchy(string name)
        {
            if (!Directory.Exists(PATH))
                Directory.CreateDirectory(PATH);

            if (AssetDatabase.LoadAssetAtPath(PATH + name + ".asset", typeof(FlowHierarchy)))
            {
                EditorUtility.DisplayDialog("erro", "Hierarchy의 이름이 이미 존재합니다.", "확인");
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                EditorUtility.DisplayDialog("erro", "Hierarchy의 이름이 비어있습니다.", "확인");
                return;
            }

            selectedNodeIndex = -1;
            flowHierarchy = CreateInstance<FlowHierarchy>();
            SetHierarchyPlayer();
            AssetDatabase.CreateAsset(flowHierarchy, PATH + name + ".asset");
            AssetDatabase.ImportAsset(PATH + name + ".asset");
        }
        void DeleteFlowHierarchy(string name)
        {
            AssetDatabase.DeleteAsset(PATH + name + ".asset");
        }
        void WindowClickCallback(object obj)
        {
            string callback = obj.ToString();
            if (callback.Equals("FlowNode"))
            {
                FlowNode flowNode = new FlowNode(mousePos.x, mousePos.y);
                flowNode.ID = ++flowHierarchy.maxID;
                flowNode.name = flowNode.ID.ToString();
                flowHierarchy.flowNodes.Add(flowNode);
            }
            else if (callback.Equals("DeleteHierarchy"))
                DeleteFlowHierarchy(deleteHierarchyName);
        }

        void CheckNodeViewMouse()
        {
            if (!flowHierarchy)
                return;
            Event e = Event.current;

            if (e.type == EventType.MouseDown)
            {
                mousePos = e.mousePosition;
                FindMouseOnNode();
                if (e.button == 0)
                    ClickLeftMouseButton(e);
                else if (e.button == 1)
                    ClickRightMouseButton(e);
            }
            if (isTransitionMode)
            {
                Rect mouseRect = new Rect(e.mousePosition.x, e.mousePosition.y, 10, 10);
                flowHierarchy.flowNodes[selectedNodeIndex].branches[branchIndex].nextFlowNodeID = 0;
                DrawLine(new Rect(clickMousePos.x, clickMousePos.y, 1, 1), mouseRect, mouseRect.x < clickMousePos.x);
                Repaint();
            }
        }
        void ClickLeftMouseButton(Event e)
        {
            if (!isTransitionMode)
                selectedNodeIndex = mouseOnNodeIndex;

            if (isTransitionMode)
            {
                if (isMouseOnNode && mouseOnNodeIndex != selectedNodeIndex)
                {
                    flowHierarchy.flowNodes[selectedNodeIndex].branches[branchIndex].nextFlowNodeID = flowHierarchy.flowNodes[mouseOnNodeIndex].ID;
                    flowHierarchy.flowNodes[mouseOnNodeIndex].parentID = flowHierarchy.flowNodes[selectedNodeIndex].ID;
                    isTransitionMode = false;
                    selectedNodeIndex = -1;
                }
                if (!isMouseOnNode)
                {
                    isTransitionMode = false;
                    selectedNodeIndex = -1;
                }
                e.Use();
            }
        }
        void ClickRightMouseButton(Event e)
        {
            if (!isMouseOnNode)
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("FlowNode 추가하기"), false, WindowClickCallback, "FlowNode");
                menu.ShowAsContext();
            }
            else
            {
                GenericMenu menu = new GenericMenu();
                if (flowHierarchy.flowNodes[mouseOnNodeIndex].ID != flowHierarchy.previewNodeID && flowHierarchy.flowNodes[mouseOnNodeIndex].ID != flowHierarchy.startNodeID)
                {
                    menu.AddItem(new GUIContent("Start Node 지정하기"), false, NodeClickCallback, "SetStartNode");
                    menu.AddItem(new GUIContent("Preview Node 지정하기"), false, NodeClickCallback, "SetPreviewNode");
                    menu.AddSeparator("");
                    menu.AddItem(new GUIContent("Node 삭제하기"), false, NodeClickCallback, "DeleteNode");
                }
                else if (flowHierarchy.flowNodes[mouseOnNodeIndex].ID == flowHierarchy.previewNodeID)
                    menu.AddItem(new GUIContent("Preview Node 초기화 하기"), false, NodeClickCallback, "ResetPreviewNode");
                menu.ShowAsContext();
            }
            e.Use();
        }
        void NodeClickCallback(object obj)
        {
            string callback = obj.ToString();
            FlowNode selectNode = flowHierarchy.flowNodes[mouseOnNodeIndex];
            if (callback.Equals("SetStartNode"))
            {
                var node = flowHierarchy.flowNodes.Find(x => x.ID == flowHierarchy.startNodeID);
                node.name = node.ID.ToString();
                flowHierarchy.startNodeID = selectNode.ID;
                selectNode.name = selectNode.ID.ToString() + " < START NODE >";
            }
            else if (callback.Equals("DeleteNode"))
            {
                if (isMouseOnNode)
                {
                    foreach (var branch in flowHierarchy.flowNodes[mouseOnNodeIndex].branches)
                    {
                        var child = flowHierarchy.flowNodes.Find(x => x.ID == branch.nextFlowNodeID);
                        child.parentID = 0;
                    }
                    flowHierarchy.flowNodes.RemoveAt(mouseOnNodeIndex);
                    selectedNodeIndex = -1;
                    isMouseOnNode = false;
                }
            }
            else if (callback.Equals("SetPreviewNode"))
            {
                var node = flowHierarchy.flowNodes.Find(x => x.ID == flowHierarchy.previewNodeID);
                if (node != null)
                    node.name = node.ID.ToString();

                flowHierarchy.previewNodeID = selectNode.ID;
                selectNode.name = selectNode.ID.ToString() + " < PREVIEW NODE >";
            }
            else if (callback.Equals("ResetPreviewNode"))
            {
                selectNode.name = selectNode.ID.ToString();
                flowHierarchy.previewNodeID = 0;
            }
        }
        void FindMouseOnNode()
        {
            for (int i = 0; i < flowHierarchy.flowNodes.Count; i++)
            {
                if (flowHierarchy.flowNodes[i].nodeRect.Contains(mousePos))
                {
                    mouseOnNodeIndex = i;
                    isMouseOnNode = true;
                    break;
                }
                else
                {
                    mouseOnNodeIndex = -1;
                    isMouseOnNode = false;
                }
            }
        }
        void DrawLine(Rect start, Rect end, bool isRight)
        {
            int endDirection = 1;
            if (!isRight) endDirection *= -1;
            Vector3 startPos = new Vector3(start.x, start.y, 0);
            Vector3 endPos = new Vector3(end.x + (10 * endDirection), end.y, 0);
            Rect arrowRect = new Rect(end.x, end.y, end.width * endDirection, end.height * endDirection);

            Vector3 startTan = startPos + Vector3.right * 100;
            Vector3 endTan = endPos + Vector3.right * endDirection * 100;

            Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.white, null, 3);

            GUI.DrawTexture(arrowRect, arrowTexture);
        }
        void ResetNodeSize(FlowNode flowNode)
        {
            flowNode.nodeRect = new Rect(flowNode.nodeRect.x, flowNode.nodeRect.y, flowNode.nodeRect.width, 10);
        }
        void SeparateLayout(int i)
        {
            for (i = 0; i < 5; i++) EditorGUILayout.Separator();
        }
        void CreateSection(float size)
        {
            GUILayoutOption[] options = { GUILayout.Width(size), GUILayout.Height(size) };
            EditorGUILayout.LabelField("", nodeBackgroundStyle, options);
            DrawGrid(20, 0.3f, Color.black, size);
            DrawGrid(100, 1f, Color.black, size);
        }
        void DrawGrid(float gridSpacing, float gridOpacity, Color gridColor, float size)
        {
            int widthDivs = Mathf.CeilToInt(size / gridSpacing);
            int heightDivs = Mathf.CeilToInt(size / gridSpacing);

            Handles.BeginGUI();
            Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);

            Vector3 newOffset = new Vector3(gridSpacing, gridSpacing, 0);

            for (int i = 0; i < widthDivs; i++)
            {
                Handles.DrawLine(new Vector3(gridSpacing * i, -gridSpacing, 0) + newOffset, new Vector3(gridSpacing * i, size, 0f) + newOffset);
            }

            for (int j = 0; j < heightDivs; j++)
            {
                Handles.DrawLine(new Vector3(-gridSpacing, gridSpacing * j, 0) + newOffset, new Vector3(size, gridSpacing * j, 0f) + newOffset);
            }
            Handles.color = Color.white;
            Handles.EndGUI();
        }
        void DrawEdges()
        {
            foreach (var flowNode in flowHierarchy.flowNodes)
            {
                if (flowNode.branches.Count == 0)
                    continue;

                for (int i = 0; i < flowNode.branches.Count; i++)
                {
                    var targetNode = flowHierarchy.flowNodes.Find(x => x.ID == flowNode.branches[i].nextFlowNodeID);
                    if (targetNode == null || flowNode.ID != targetNode.parentID)
                    {
                        flowNode.branches[i].nextFlowNodeID = 0;
                        continue;
                    }

                    Rect startRect = new Rect(flowNode.nodeRect.x + flowNode.nodeRect.width, flowNode.nodeRect.y + (flowNode.nodeRect.height * 2 - (flowNode.branches.Count - i) * 26 + 4) / 2, 0, 0);
                    Rect endRect;
                    if (targetNode.nodeRect.x - targetNode.nodeRect.width / 2 < flowNode.nodeRect.x)
                        endRect = new Rect(targetNode.nodeRect.x + targetNode.nodeRect.width, targetNode.nodeRect.y + targetNode.nodeRect.height / 2, 10, 10);
                    else
                        endRect = new Rect(targetNode.nodeRect.x, targetNode.nodeRect.y + targetNode.nodeRect.height / 2, 10, 10);

                    DrawLine(startRect, endRect, targetNode.nodeRect.x - targetNode.nodeRect.width / 2 < flowNode.nodeRect.x);
                }
            }
        }
        void DrawNodes()
        {
            BeginWindows();
            for (int i = 0; i < flowHierarchy.flowNodes.Count; i++)
            {
                if (EditorApplication.isPlaying)
                {
                    if (flowHierarchy.currentNodeID == flowHierarchy.flowNodes[i].ID)
                        GUI.color = Color.cyan;
                    else
                        GUI.color = Color.white;
                }
                else
                {
                    if (flowHierarchy.flowNodes[i].ID == flowHierarchy.startNodeID)
                        GUI.color = previewNodeColor;
                    else if (flowHierarchy.flowNodes[i].ID == flowHierarchy.previewNodeID)
                        GUI.color = startNodeColor;
                    else if (i == selectedNodeIndex)
                        GUI.color = selectedNodeColor;
                    else
                        GUI.color = Color.white;
                }
                flowHierarchy.flowNodes[i].nodeRect = GUILayout.Window(i, flowHierarchy.flowNodes[i].nodeRect, DrawNodeWindow, flowHierarchy.flowNodes[i].name);
            }
            GUI.color = Color.white;
            EndWindows();
        }
        void AddNodeActionCallback(object obj)
        {
            string key = obj.ToString();
            flowHierarchy.flowNodes[selectedNodeIndex].actions.Add(new ActionInfo(key));
        }
        void AddNodeBranchCallback(object obj)
        {
            string key = obj.ToString();
            flowHierarchy.flowNodes[selectedNodeIndex].branches.Add(new BranchInfo(key));
        }
        void DrawNodeWindow(int id)
        {
            if (flowHierarchy.flowNodes.Count <= id)
                return;

            if (GUILayout.Button("+ Action"))
            {
                GenericMenu menu = new GenericMenu();
                foreach (var action in actionList)
                    menu.AddItem(new GUIContent(action.Key), false, AddNodeActionCallback, action.Key);
                menu.ShowAsContext();
            }

            for (int i = 0; i < flowHierarchy.flowNodes[id].actions.Count; i++)
                DrawNodeAction(i, flowHierarchy.flowNodes[id].actions[i]);

            if (GUILayout.Button("+ Branch"))
            {
                GenericMenu menu = new GenericMenu();
                foreach (var condition in conditionList)
                    menu.AddItem(new GUIContent(condition.Key), false, AddNodeBranchCallback, condition.Key);
                menu.ShowAsContext();
            }

            for (int i = 0; i < flowHierarchy.flowNodes[id].branches.Count; i++)
                DrawNodeBranch(flowHierarchy.flowNodes[id].branches[i], i);

            GUI.DragWindow();
        }
        void DrawNodeAction(int i, ActionInfo action)
        {
            EditorGUILayout.BeginHorizontal();

            layoutStyle.alignment = TextAnchor.MiddleLeft;
            layoutStyle.normal.textColor = Color.red;
            if (GUILayout.Button("-", layoutStyle))
            {
                flowHierarchy.flowNodes[selectedNodeIndex].actions.RemoveAt(i);
                ResetNodeSize(flowHierarchy.flowNodes[selectedNodeIndex]);
            }

            actionList[action.actionName].DisplayNodeView();
            action.finishConditionIndex = EditorGUILayout.Popup(action.finishConditionIndex, finishCondtionList.ToArray(), GUILayout.Width(70));
            action.finishCondtionName = finishCondtionList[action.finishConditionIndex];
            EditorGUILayout.EndHorizontal();
        }
        void DrawNodeBranch(BranchInfo branch, int id)
        {
            EditorGUILayout.BeginHorizontal();
            layoutStyle.alignment = TextAnchor.MiddleLeft;
            layoutStyle.normal.textColor = Color.red;
            if (GUILayout.Button("-", layoutStyle))
            {
                var node = flowHierarchy.flowNodes.Find(x => x.ID == flowHierarchy.flowNodes[selectedNodeIndex].branches[id].nextFlowNodeID);
                if (node != null)
                    node.parentID = 0;
                flowHierarchy.flowNodes[selectedNodeIndex].branches.RemoveAt(id);
                ResetNodeSize(flowHierarchy.flowNodes[selectedNodeIndex]);
            }
            conditionList[branch.branchName].DisplayNodeView();

            layoutStyle.alignment = TextAnchor.MiddleRight;
            layoutStyle.normal.textColor = Color.green;
            if (GUILayout.Button("+", layoutStyle))
            {
                branchIndex = id;
                clickMousePos = mousePos;
                flowHierarchy.flowNodes[selectedNodeIndex] = flowHierarchy.flowNodes[mouseOnNodeIndex];
                isTransitionMode = true;
                var node = flowHierarchy.flowNodes.Find(x => x.ID == flowHierarchy.flowNodes[selectedNodeIndex].branches[branchIndex].nextFlowNodeID);
                if (node != null)
                    node.parentID = 0;
            }
            EditorGUILayout.EndHorizontal();
        }
        void DrawUILine(Color color, int thickness = 2, int padding = 10)
        {
            Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
            r.height = thickness;
            r.y += padding / 2;
            r.x -= 2;
            r.width += 6;
            EditorGUI.DrawRect(r, color);
        }
    }
}

