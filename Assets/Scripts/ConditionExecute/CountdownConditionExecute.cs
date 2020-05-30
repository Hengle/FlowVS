using System.Collections;
using FLOW;
using FLOW.Exetue;
using FLOW.Player;
using UnityEngine;

public class CountdownConditionExecute : IConditionExecute
{
    IEnumerator IConditionExecute.CheckCondition(FinishInfo info, Transform player)
    {
        yield return new WaitForSeconds(info.subFloat);
    }
}
