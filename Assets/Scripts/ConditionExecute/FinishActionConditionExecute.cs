using System.Collections;
using FLOW;
using FLOW.Exetue;
using FLOW.Player;
using UnityEngine;

class FinishActionConditionExecute : IConditionExecute
{
    IEnumerator IConditionExecute.CheckCondition(FinishInfo info, Transform player)
    {
        while (info.isPlaying)
            yield return null;
    }
}
