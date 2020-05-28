using UnityEngine;

namespace FLOW
{
    [System.Serializable]
    public class BranchInfo
    {
        public string branchName;
        public int nextFlowNodeID;
        public int finishConditionIndex;
        public FinishInfo finishInfo = new FinishInfo();

        public BranchInfo(string name)
        {
            branchName = name;
        }
    }
}
