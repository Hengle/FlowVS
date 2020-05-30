using System.Collections;
using FLOW;
using FLOW.Exetue;
using FLOW.Player;
using UnityEngine;

class AnykeyConditionExecute : IConditionExecute
{
    IEnumerator IConditionExecute.CheckCondition(FinishInfo info, Transform player)
    {
        while (true)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.RightArrow)||Input.GetMouseButtonDown(0))
                break;
        }
    }
}

