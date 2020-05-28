using System.Collections.Generic;
using UnityEngine;

namespace FLOW
{
    [System.Serializable]
    public class FlowNode
    {
        public Rect nodeRect;
        public string name;
        public int ID;
        public int parentID;
        public List<ActionInfo> actions = new List<ActionInfo>();
        public List<BranchInfo> branches = new List<BranchInfo>();

        public FlowNode()
        {
            nodeRect = new Rect(Screen.width / 4, Screen.height / 4, 237, 32);
        }

        public FlowNode(float xPosition, float yPosition)
        {
            nodeRect = new Rect(xPosition, yPosition, 237, 32);
        }
    }
}