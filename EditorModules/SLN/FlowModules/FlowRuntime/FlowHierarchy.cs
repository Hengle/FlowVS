using System.Collections.Generic;
using UnityEngine;

namespace FLOW
{
    public class FlowHierarchy : ScriptableObject
    {
        public int startNodeID = 1;
        public int currentNodeID;
        public int previewNodeID;
        public int maxID = 1;
        public GameObject hierarchyPlayer;

        public List<FlowNode> flowNodes = new List<FlowNode>();

        public FlowHierarchy()
        {
            FlowNode startNode = new FlowNode();
            startNode.ID = maxID;
            startNode.name = string.Format(startNode.ID.ToString() + "< START NODE >");
            flowNodes.Add(startNode);
        }
    }
}
