using FLOW.Player;
using System.Collections;
using UnityEngine;

namespace FLOW.Exetue
{
    public interface IActionExecute
    {
        IEnumerator ExecuteAction(ActionInfo info, Transform player);
        void FinishAction(ActionInfo info, Transform player);
    }
}