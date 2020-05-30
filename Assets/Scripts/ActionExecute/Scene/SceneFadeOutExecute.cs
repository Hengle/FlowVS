using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;

public class SceneFadeOutExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        var fadePanel = player.GetComponentInChildren<CustomFadePanel>();
        yield return fadePanel.FadeOut(info.floatNumber);
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        var fadePanel = player.GetComponentInChildren<CustomFadePanel>();
        fadePanel.FadeOutFinish();
    }
}

