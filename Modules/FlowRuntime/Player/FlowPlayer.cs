using LineStudio.Exetue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FLOW.Player
{
    public abstract class FlowPlayer : MonoBehaviour
    {
        public Dictionary<string, IActionExecute> actions = new Dictionary<string, IActionExecute>();
        public Dictionary<string, IConditionExecute> conditions = new Dictionary<string, IConditionExecute>();
        FlowHierarchy flowHierarchy;

        Stack<int> previousPreviewNodeID = new Stack<int>();
        List<IEnumerator> branchCoroutines = new List<IEnumerator>();
        BranchInfo selectedBranch;

        protected abstract void AddActionList();
        protected abstract void AddConditionList();
        public IEnumerator Play(FlowHierarchy flowHierarchy)
        {
            this.flowHierarchy = flowHierarchy;
            flowHierarchy.currentNodeID = flowHierarchy.startNodeID;
            if (flowHierarchy.previewNodeID != 0)
            {
                flowHierarchy.currentNodeID = flowHierarchy.previewNodeID;
                PreviewPlay();
            }
            var node = flowHierarchy.flowNodes.Find(x => x.ID == flowHierarchy.currentNodeID);

            yield return CExecuteNode(node);
            Destroy(gameObject);
        }
        public void PreviewPlay()
        {
            PushParentID();
            FlowNode currentNode;
            while (previousPreviewNodeID.Count != 0)
            {
                int previousNodeID = previousPreviewNodeID.Pop();
                currentNode = flowHierarchy.flowNodes.Find(x => x.ID == previousNodeID);
                foreach (var info in currentNode.actions)
                    actions[info.actionName].FinishAction(info,transform);
            }
        }
        void PushParentID()
        {
            FlowNode node = flowHierarchy.flowNodes.Find(x => x.ID == flowHierarchy.previewNodeID);
            int parentID = node.parentID;

            while (parentID != 0)
            {
                if (previousPreviewNodeID.Contains(parentID))
                    break;
                previousPreviewNodeID.Push(parentID);
                node = flowHierarchy.flowNodes.Find(x => x.ID == parentID);
                parentID = node.parentID;
            }
        }
        IEnumerator CExecuteNode(FlowNode node)
        {
            flowHierarchy.currentNodeID = node.ID;
            selectedBranch = null;

            foreach (var info in node.actions)
            {
                info.finishInfo.isPlaying = true;
                StartCoroutine(actions[info.actionName].ExecuteAction(info, transform));
                yield return conditions[info.finishCondtionName].CheckCondition(info.finishInfo, transform);
            }

            int disableBranchCount = 0;
            foreach (var branch in node.branches)
            {
                if (branch.nextFlowNodeID == 0)
                {
                    disableBranchCount++;
                    continue;
                }
                IEnumerator branchCoroutine = CBranchConditionCheck(branch);
                branchCoroutines.Add(branchCoroutine);
                StartCoroutine(branchCoroutine);
            }

            while (node.branches.Count > disableBranchCount && selectedBranch == null)
            {
                yield return null;
            }

            if (selectedBranch != null)
                yield return CMoveNextNode(selectedBranch);
        }
        IEnumerator CBranchConditionCheck(BranchInfo branch)
        {
            yield return conditions[branch.branchName].CheckCondition(branch.finishInfo, transform);
            selectedBranch = branch;
        }
        public void Stop()
        {
        }
        IEnumerator CMoveNextNode(BranchInfo nodeBranch)
        {
            StopAllBranchCoroutine();
            var node = flowHierarchy.flowNodes.Find(x => x.ID == nodeBranch.nextFlowNodeID);
            yield return CExecuteNode(node);
        }
        void StopAllBranchCoroutine()
        {
            foreach (var branchCoroutine in branchCoroutines)
                StopCoroutine(branchCoroutine);
        }
        void Awake()
        {
            AddActionList();
            AddConditionList();
        }
    }
}