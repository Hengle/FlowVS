using System.Collections;
using FLOW;
using FLOW.Exetue;
using FLOW.Player;
using UnityEngine;

class NoneConditionExecute : IConditionExecute
{
    IEnumerator IConditionExecute.CheckCondition(FinishInfo info, Transform player)
    {
        yield return null;
    }
}
