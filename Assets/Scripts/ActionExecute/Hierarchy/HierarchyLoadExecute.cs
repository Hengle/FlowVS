using System.Collections;
using FLOW;
using FLOW.Exetue;
using FLOW.Player;
using UnityEngine;

public class HierarchyLoadExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        if (info.flowHierarchy != null)
        {
            var hierarchyPlayer = Object.Instantiate(info.flowHierarchy.hierarchyPlayer);
            yield return hierarchyPlayer.GetComponent<FlowPlayer>().Play(info.flowHierarchy);
            yield return null;
        }
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        if (info.flowHierarchy == null)
            return;
        var hierarchyPlayer = Object.Instantiate(info.flowHierarchy.hierarchyPlayer);
        hierarchyPlayer.GetComponent<CustomPlayer>().SetFinish(info.flowHierarchy);
    }
}
