using LineStudio.Player;
using System.Collections;
using UnityEngine;

namespace FLOW.Exetue
{
    public interface IConditionExecute
    {
        IEnumerator CheckCondition(FinishInfo actionInfo, Transform player);
    }
}