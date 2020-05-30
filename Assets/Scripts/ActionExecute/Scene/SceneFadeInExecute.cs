using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;

public class SceneFadeInExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        var fadePanel = player.GetComponentInChildren<CustomFadePanel>();
        yield return fadePanel.FadeIn(info.floatNumber);
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        var fadePanel = player.GetComponentInChildren<CustomFadePanel>();
        fadePanel.FadeInFinish();
    }
}

