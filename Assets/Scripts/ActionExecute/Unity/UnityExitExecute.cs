using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;

public class UnityExitExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        yield return null;
        info.finishInfo.isPlaying = false;
        Application.Quit();
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        Application.Quit();
    }
}
